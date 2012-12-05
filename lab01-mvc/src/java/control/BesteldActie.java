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
public class BesteldActie implements ServletActie {

    ServletContext context;

    public BesteldActie(ServletContext context) {
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
        int aantalnormaal = Integer.valueOf(normaal);
        int aantalreductie = Integer.valueOf(reductie);
        double prijs = aantalnormaal * concert.getPrijsNormaal() + aantalreductie * concert.getPrijsReductie();
        request.setAttribute("aantalnormaal", aantalnormaal);
        request.setAttribute("aantalreductie", aantalreductie);
        request.setAttribute("naam", naam);
        request.setAttribute("concertid", concertid);
        request.setAttribute("concert", concert);
        request.setAttribute("prijs", prijs);
        request.setAttribute(Controller.PARAM_VIEW, Controller.JSP_BESTELD);
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
