/* 
 * File:   main.cpp
 * Author: Ah Lun Tang
 *
 * Created on December 4, 2012, 2:31 PM
 */

#include <cstdlib>
#include <boost/algorithm/string.hpp>
#include "socket.h"

using namespace std;

/*
 * 
 */
int main(int argc, char** argv) {
    int sock = maak_tcp_socket();
    cout << "socket aangemaakt op:" << sock << endl;

    verbind_en_luister(sock, 1337);

    int connectie;
    const int MAX_LIJN = 256;
    char buffer[MAX_LIJN];
    while (true) {
        connectie = accepteer(sock);
        if (connectie < 0) {
            cout << "probleem client" << endl;
        } else {
            cout << "client connected" << endl;
            int aantal_ontvangen = recv(connectie, buffer, MAX_LIJN - 1, 0);
            while (aantal_ontvangen > 0) {
                buffer[aantal_ontvangen] = 0;
                string citaat = string(buffer);
                cout << "client said: " << citaat << endl;
                int aantal_verzonden = send(connectie, buffer, strlen(buffer), 0);
                if (aantal_verzonden < 0)
                    perror("send");
                if(citaat.substr(0,4) != "stop"){
                        aantal_ontvangen = recv(connectie, buffer, MAX_LIJN - 1, 0);
                } else {
                    aantal_ontvangen = 0;
                }
            }
            sluit(connectie);
            cout << "connection closed" << endl;
        }
    }
    cout << "gedaan" << endl;
    return 0;
}

