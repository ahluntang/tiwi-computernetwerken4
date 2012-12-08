#ifndef _SOCKET_H_
#define _SOCKET_H_

#include <iostream>
#include <sstream>
#include <stdexcept>

#include <sys/types.h>
#include <sys/socket.h>
#include <stdlib.h> // exit
#include <netinet/in.h> // IPPROTO_TCP 
#include <arpa/inet.h> // inet_ntoa

#include <errno.h>
#include <stdio.h>
#include <string.h>


#include <sys/types.h>
#include <sys/socket.h>
#include <netdb.h>

template <typename T>
std::string to_string(const T &x) {
    std::ostringstream os;
    os << x;
    return os.str();
}

struct NetwerkExceptie : public std::runtime_error {

    NetwerkExceptie(const std::string & s)
    : std::runtime_error(s) {
    }
};

// Maakt een standaard tcp-socket (IPv4 en streaming) en geeft descriptor terug. 
// throws NetwerkExceptie indien dit niet lukt.

int maak_tcp_socket() {
    int listenfd = socket(PF_INET, SOCK_STREAM, IPPROTO_TCP);
    if (listenfd < 0) {
        std::string fout = "Probleem maak tcp socket:";
        fout += strerror(errno);
        throw NetwerkExceptie(fout.c_str());
    }
    return listenfd;
}

// Sluit de socket met descriptor sd.	
// throws NetwerkExceptie indien dit niet lukt.

void sluit(int sd) {
    int sluit = close(sd);
    if (sluit < 0) {
        std::string fout = "Probleem sluiten:";
        fout += strerror(errno);
        throw NetwerkExceptie(fout.c_str());
    }
}

// Maakt een socket-adres aan de hand van gegeven 'ip' en 'poort'.

sockaddr_in maak_adres(unsigned long ip, short poort) {
    sockaddr_in adres;
    memset(&adres, 0, sizeof (adres));
    adres.sin_family = AF_INET;
    adres.sin_addr.s_addr = ip; // NIET htonl(ip);
    adres.sin_port = htons(poort);
    return adres;
}

// Maakt een socket-adres aan de hand van gegeven 'servernaam' (bv. "localhost") en 'poort'.
// throws NetwerkExceptie indien gethostbyname problemen geeft.

sockaddr_in maak_adres(const std::string &servernaam, int poort) {
    hostent *server = gethostbyname(servernaam.c_str());
    if (server == 0) {
        std::string fout = "Problem resolving hostname:";
        fout += strerror(errno);
        throw NetwerkExceptie(fout.c_str());
    }
    unsigned long ip = *((unsigned long *) server->h_addr_list[0]);
    return maak_adres(ip, poort);
}

// Maakt een server-adres dat luistert op de gegeven 'poort' (op alle netwerkinterfaces).

sockaddr_in maak_server_adres(short poort) {
    sockaddr_in server_adres;
    memset(&server_adres, 0, sizeof (server_adres)); // maak struct leeg
    server_adres.sin_family = AF_INET; // internetadres
    server_adres.sin_addr.s_addr = htonl(INADDR_ANY); // serveradres
    server_adres.sin_port = htons(poort);
    return server_adres;
}

// Laat server-socket (descriptor sd) luisteren op de gegeven poort (max. 10 connecties).    
// throws NetwerkExceptie indien er een fout optreedt.

void verbind_en_luister(int sd, short poort) {
    // registreer adres
    sockaddr_in server = maak_server_adres(poort);
    // bind dit adres voor onze applicatie
    int returnwaarde = bind(sd, (sockaddr*) & server, sizeof(server));
    if (returnwaarde < 0) {
        std::string fout = "Problem bind():";
        fout += strerror(errno);
        throw NetwerkExceptie(fout.c_str());
    }
    int listenwaarde = listen(sd, 10);
    if (listenwaarde < 0){
        std::string fout = "Problem listen():";
        fout += strerror(errno);
        throw NetwerkExceptie(fout.c_str());
    }
}

// Laat server-socket (descriptor sd) wachten op een client die wil connecteren.
// Return de socketdescriptor van de client.
// throws NetwerkExceptie indien er een fout optreedt.

int accepteer(int sd) {

    sockaddr_in client_adres;
    unsigned int lengte = sizeof (client_adres);
    int connfd = accept(sd, (sockaddr *) &client_adres, &lengte);

    if (connfd < 0) {
        std::string fout = "Problem accept():";
        fout += strerror(errno);
        throw NetwerkExceptie(fout.c_str());
    }
    return connfd;
}

// Probeert client-socket (descriptor sd) te connecteren met gegeven server-adres.
// throws NetwerkExceptie indien er een fout optreedt.

void connecteer(int sd, const sockaddr_in &adres) {
    int returnwaarde = connect(sd, (struct sockaddr *) &adres, sizeof (adres));
    if (returnwaarde < 0) {
        std::string fout = "Problemen met connect(): ";
        fout += strerror(errno);
        throw NetwerkExceptie(fout.c_str());
    }
}


// Probeert client-socket (descriptor sd) te connecteren met gegeven server-IP en poort.
// throws NetwerkExceptie indien er een fout optreedt.

void connecteer(int sd, unsigned long ip, short poort) {
    connecteer(sd, maak_adres(ip, poort));
}


// Probeert client-socket (descriptor sd) te connecteren met gegeven servernaam en poort.
// throws NetwerkExceptie indien er een fout optreedt.

void connecteer(int sd, const std::string &servernaam, short poort) {
    connecteer(sd, maak_adres(servernaam, poort));
}

// Probeert string 's' te schrijven naar socket met descriptor 'sd'.
// Return aantal effectief uitgeschreven.
// throws NetwerkExceptie indien er een fout optreedt. 

int schrijf(int sd, const std::string &s) {

}

// Probeert 'buflen' karakters in te lezen in 'buffer' uit socket met descriptor 'sd'.
// Eeturn aantal effectief ingelezen.
// throws NetwerkExceptie indien er een fout optreedt. 

int lees(int sd, char *buffer, int buflen) {

}



#endif
