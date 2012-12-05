/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package control;

import dao.IConcertDAO;
import javax.servlet.ServletContext;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import model.Concert;

/**
 *
 * @author Ah Lun Tang
 */
public class ToonConcertActie implements ServletActie {
    ServletContext context;
    
    
    public ToonConcertActie(ServletContext context) {
        this.context = context;
    }
    
    public void execute(HttpServletRequest request, 
            HttpServletResponse response) {
        
        String naam =  request.getParameter("naam");
        String aantalnormaal =  request.getParameter("aantalnormaal");
        String aantalreductie =  request.getParameter("aantalreductie");
        String sconcertid =  request.getParameter("concertid");
        Long concertid = Long.valueOf(sconcertid);
        IConcertDAO concerten = (IConcertDAO) context.getAttribute("concerten");
        Concert concert = concerten.getConcert(concertid);
        
        request.setAttribute("concert", concert);
        request.setAttribute("concertid", concertid);
        request.setAttribute("naam", naam);
        request.setAttribute("aantalnormaal", aantalnormaal);
        request.setAttribute("aantalreductie", aantalreductie);
        request.setAttribute(Controller.PARAM_VIEW, Controller.JSP_CONCERT);
    }
    
}
