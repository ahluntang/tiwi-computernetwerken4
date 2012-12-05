/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package web;

import dao.DummyConcertDAO;
import dao.IConcertDAO;
import javax.enterprise.context.ApplicationScoped;
import javax.servlet.ServletContext;
import javax.servlet.ServletContextEvent;
import javax.servlet.ServletContextListener;
import javax.servlet.annotation.WebListener;

/**
 * Web application lifecycle listener.
 *
 * @author Ah Lun Tang
 */
@WebListener()
public class InitListener implements ServletContextListener {
    
     public InitListener() {};

    @Override
    public void contextInitialized(ServletContextEvent event) {
        ServletContext context = event.getServletContext();
        try {
            String klasse = context.getInitParameter("klasseOverzichtConcerten");
            IConcertDAO concertdao =
                    (IConcertDAO) Class.forName(klasse).newInstance();
            context.setAttribute("concerten", concertdao);
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }

    @Override
    public void contextDestroyed(ServletContextEvent sce) {
        throw new UnsupportedOperationException("Not supported yet.");
    }
}
