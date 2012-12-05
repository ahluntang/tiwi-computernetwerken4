/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package control;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

/**
 *
 * @author Ah Lun Tang
 */
public interface ServletActie {
    void execute(HttpServletRequest request, 
            HttpServletResponse response);
}
