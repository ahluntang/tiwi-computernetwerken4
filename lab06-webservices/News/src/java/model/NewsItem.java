package model;

import java.util.Date;

/**
 * @author wijnand.schepens@hogent.be
 */
public class NewsItem
{
	private String author;
	private String title;
	private String message;
	private Date   date;

	public NewsItem(String author, String title, String message, Date date)
	{
		this.author = author;
		this.title = title;
		this.message = message;
		this.date = date;
	}
	
	public Date getDate()
	{
		return date;
	}

	public String getTitle()
	{
		return title;
	}

	public String getMessage()
	{
		return message;
	}

	public String getAuthor()
	{
		return author;
	}
		
	@Override
	public String toString()
	{
		return author + ": " + title + " (" + date + "): " + message;
	}
	
}
