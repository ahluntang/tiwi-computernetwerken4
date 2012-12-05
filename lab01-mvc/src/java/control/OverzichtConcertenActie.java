/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package control;

import control.Controller;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

/**
 *
 * @author Ah Lun Tang
 */
public class OverzichtConcertenActie  implements ServletActie {
    
    /** Creates a new instance of OverzichtStedenActie */
    public OverzichtConcertenActie() {
    }
    
    public void execute(HttpServletRequest request, 
            HttpServletResponse response) {
        request.setAttribute(Controller.PARAM_VIEW, 
                Controller.JSP_OVERZICHT);
    }
    
}
