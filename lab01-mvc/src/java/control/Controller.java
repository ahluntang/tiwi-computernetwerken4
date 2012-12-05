/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package control;

import java.io.IOException;
import java.util.HashMap;
import java.util.Map;
import javax.servlet.RequestDispatcher;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

/**
 *
 * @author Ah Lun Tang
 */
public class Controller extends HttpServlet {
    
    // relatieve URL's JSP's
    
    protected static final String JSP_OVERZICHT = "concerten.jsp";
    protected static final String JSP_CONCERT = "concert.jsp";
    protected static final String JSP_BEVESTIGING = "bevestiging.jsp";
    protected static final String JSP_BESTELD = "besteld.jsp";
    private static final String JSP_TEMPLATE = "template.jsp";
    
    // URL's acties
    private static final String DO_OVERZICHT = "overzicht.do";
    public static final String DO_RESERVATIE = "reservatie.do";
    public static final String DO_BEVESTIGING = "naarbevestiging.do";
    public static final String DO_BESTELD = "besteld.do";
    
    // parameters
    private static final String LIJST_ACTIES = "acties";
    protected static final String PARAM_VIEW = "view";
    
    /** Processes requests for both HTTP <code>GET</code> and <code>POST</code> methods.
     * @param request servlet request
     * @param response servlet response
     */
    protected void processRequest(HttpServletRequest request,  HttpServletResponse response) throws ServletException, IOException {
                doActieEnBepaalView(request,response);
        RequestDispatcher dispatcher = 
                request.getRequestDispatcher(JSP_TEMPLATE);
        dispatcher.forward(request,response);
    }
    
      private void doActieEnBepaalView(HttpServletRequest request,
            HttpServletResponse response) {
        String pad = request.getServletPath();
        if (pad != null) {
            String naamActie = pad.substring(1);
            Map<String,ServletActie> acties = (Map<String,ServletActie>)
                getServletContext().getAttribute(LIJST_ACTIES);
            ServletActie actie = acties.get(naamActie.toLowerCase());
            actie.execute(request,response);
        } else {
            request.setAttribute(PARAM_VIEW, JSP_OVERZICHT);
        }
    }

     public void init() {
        Map<String,ServletActie> acties = lijstActies();
        getServletContext().setAttribute(LIJST_ACTIES,acties);
    }
    
    private Map lijstActies() {
        HashMap<String,ServletActie> acties =
                new HashMap<String,ServletActie>();
        acties.put(DO_OVERZICHT, new OverzichtConcertenActie());
        acties.put(DO_RESERVATIE,new ToonConcertActie(getServletContext()));
        acties.put(DO_BEVESTIGING,new NaarBevestigingActie(getServletContext()));
        acties.put(DO_BESTELD,new BesteldActie(getServletContext()));
        return acties;
    }

    
    // <editor-fold defaultstate="collapsed" desc="HttpServlet methods. Click on the + sign on the left to edit the code.">
    /** Handles the HTTP <code>GET</code> method.
     * @param request servlet request
     * @param response servlet response
     */
    protected void doGet(HttpServletRequest request, HttpServletResponse response)
    throws ServletException, IOException {
        processRequest(request, response);
    }
    
    /** Handles the HTTP <code>POST</code> method.
     * @param request servlet request
     * @param response servlet response
     */
    protected void doPost(HttpServletRequest request, HttpServletResponse response)
    throws ServletException, IOException {
        processRequest(request, response);
    }
    
    /** Returns a short description of the servlet.
     */
    public String getServletInfo() {
        return "Short description";
    }
    // </editor-fold>
}
