/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package control;

import dao.IConcertDAO;
import java.util.ArrayList;
import java.util.Collection;
import javax.servlet.ServletContext;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import model.Concert;

/**
 *
 * @author Ah Lun Tang
 */
public class NaarBevestigingActie implements ServletActie {

    ServletContext context;

    public NaarBevestigingActie(ServletContext context) {
        this.context = context;
    }

    public void execute(HttpServletRequest request,
            HttpServletResponse response) {
        String normaal = request.getParameter("aantalnormaal");
        String reductie = request.getParameter("aantalreductie");
        Long concertid = Long.valueOf(request.getParameter("concertid"));
        String naam = request.getParameter("naam");
        IConcertDAO concerten = (IConcertDAO) context.getAttribute("concerten");
        Concert concert = concerten.getConcert(concertid);
        Collection<String> foutberichten = new ArrayList<String>();
        int aantalnormaal = 0;
        int aantalreductie = 0;
        if(isInteger(normaal)){
            aantalnormaal = Integer.valueOf(normaal);
        } else {
            foutberichten.add("Aantal normale tickets verkeerd ingevuld!");
        }
        if(isInteger(reductie)){
            aantalreductie = Integer.valueOf(reductie);
        } else {
            foutberichten.add("Aantal reductie tickets verkeerd ingevuld!");
        }
        if (aantalnormaal < 0) {
            foutberichten.add("Aantal normale tickets is negatief!");
        }
        if (aantalreductie < 0) {
            foutberichten.add("Aantal reductie tickets is negatief!");
        }
        if (aantalreductie + aantalnormaal <= 0) {
            foutberichten.add("Geen tickets geselecteerd!");
        }
        if (naam.equals("")) {
            foutberichten.add("Naam niet correct ingevuld!");
        }
        double prijs = aantalnormaal * concert.getPrijsNormaal() + aantalreductie * concert.getPrijsReductie();
        request.setAttribute("aantalnormaal", aantalnormaal);
        request.setAttribute("aantalreductie", aantalreductie);
        request.setAttribute("naam", naam);
        request.setAttribute("concertid", concertid);
        request.setAttribute("concert", concert);
        request.setAttribute("prijs", prijs);
        if (foutberichten.size() > 0) {
            request.setAttribute("foutberichten", foutberichten);
            request.setAttribute(Controller.PARAM_VIEW, Controller.JSP_CONCERT);
        } else {
            request.setAttribute(Controller.PARAM_VIEW, Controller.JSP_BEVESTIGING);
        }
    }

    public boolean isInteger(String input) {
        try {
            Integer.parseInt(input);
            return true;
        } catch (Exception ex) {
            return false;
        }
    }
}
