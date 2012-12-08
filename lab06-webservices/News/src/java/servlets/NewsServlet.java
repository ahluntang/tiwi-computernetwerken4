/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package servlets;

import java.io.IOException;
import java.io.InputStream;
import java.io.PrintWriter;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.Scanner;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import model.News;
import model.NewsItem;
import org.json.JSONObject;

/**
 *
 * @author Wijnand
 */
public class NewsServlet extends HttpServlet
{

	private News getNews(HttpServletRequest request)
	{

		News news = (News) request.getServletContext().getAttribute("news");
		if (news == null)
		{
			news = new News();
			news.addNewsItem(new NewsItem("Anoniem", "Webservice", "Yahoo! Mijn eerste webservice!", new Date()));
			
			request.getServletContext().setAttribute("news", news);
		}
		return news;
	}
        
        private NewsItem getNewsItem(HttpServletRequest request,String id){
            News news = (News) request.getServletContext().getAttribute("news");
            return news.getNewsItem(id);
        }

	
	private String createJSON(News news) 
	{
		// TODO: use org.json instead...
		StringBuilder sb = new StringBuilder();
		sb.append("[ ");
		boolean first = true;
		for (String eid : news.getNewsItemIds())
		{
			NewsItem entry = news.getNewsItem(eid);
                        
                        
                        
                        SimpleDateFormat formatter = new SimpleDateFormat("dd-MMM-yy");
                        String datestring = formatter.format(entry.getDate());
                        
                        
			if (!first)
				sb.append(", ");
			sb.append("{ \"id\":\"")
			  .append(eid)
			  .append("\", \"title\":\"")
			  .append(entry.getTitle())
			  .append("\", \"message\":\"")
			  .append(entry.getMessage())
			  .append("\", \"author\":\"")
			  .append(entry.getAuthor())
			  .append("\", \"date\":\"")
			  .append(datestring)
			  .append("\" }");
			first = false;
		}
		sb.append(" ]\n");
		return sb.toString();
	}
	
	
	private String createJSON(NewsItem item) 
	{
		// TODO: use org.json instead...
		StringBuilder sb = new StringBuilder();
		sb.append("{ ")
		  .append("\"author\":\"").append(item.getAuthor()).append("\", ")
		  .append("\"title\":\"").append(item.getTitle()).append("\", ")
		  .append("\"message\":\"").append(item.getMessage()).append("\", ")
		  .append("\"date\":\"").append(item.getDate()).append("\" }");
		return sb.toString();
	}	
	
	private NewsItem readNewsItemFromContent(InputStream stream) throws Exception
	{
		Scanner sc = new Scanner(stream);
		sc.useDelimiter("\\Z");  // till EOF
		String content = sc.next();  // whole file
		JSONObject obj = new JSONObject(content);
		String author = obj.getString("author");
		String title = obj.getString("title");
		String message = obj.getString("message");
		return new NewsItem(author, title, message, new Date());
	}

	
	@Override
	protected void doGet(HttpServletRequest request, HttpServletResponse response)
			throws ServletException, IOException
	{
            String parts[] = request.getRequestURI().split("/");
            if(parts.length == 4){
                NewsItem item = getNewsItem(request, parts[3]);
                String newsjson = createJSON(item);
                PrintWriter out = response.getWriter();
                out.print(newsjson);
            } else {
                News news = getNews(request);
                String newsjson = createJSON(news);
                PrintWriter out = response.getWriter();
                out.print(newsjson);
            }
	}

	/** 
	 * Handles the HTTP <code>POST</code> method.
	 * @param request servlet request
	 * @param response servlet response
	 * @throws ServletException if a servlet-specific error occurs
	 * @throws IOException if an I/O error occurs
	 */
	@Override
	protected void doPost(HttpServletRequest request, HttpServletResponse response)
			throws ServletException, IOException
	{
		String author = request.getParameter("author");
		String title = request.getParameter("title");
		String message = request.getParameter("message");
                NewsItem item = new NewsItem(author, title, message, new Date());
                News news = (News) request.getServletContext().getAttribute("news");
                news.addNewsItem(item);
	}

	@Override
	protected void doPut(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException
	{
			
	}

	@Override
	protected void doDelete(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException
	{
		
	
	}

	/** 
	 * Returns a short description of the servlet.
	 * @return a String containing servlet description
	 */
	@Override
	public String getServletInfo()
	{
		return "Servlet for News REST web service";
	}
	
}
