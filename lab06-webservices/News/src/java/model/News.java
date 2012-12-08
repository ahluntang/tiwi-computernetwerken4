package model;

import java.util.Map;
import java.util.Set;
import java.util.TreeMap;

/**
 * @author wijnand.schepens@hogent.be
 */
public class News 
{
	private int nextId = 1;
	private Map<String, NewsItem> newsItems = new TreeMap<String, NewsItem>();
	
	public Set<String> getNewsItemIds()
	{
		return newsItems.keySet();
	}
	
	public boolean containsNewsItemId(String id)
	{
		return newsItems.containsKey(id);
	}
	
	public NewsItem getNewsItem(String id) throws UnknownIdException
	{
		if (newsItems.containsKey(id))
			return newsItems.get(id);
		else
			throw new UnknownIdException(id);
	}
	
	public void deleteNewsItem(String id) throws UnknownIdException
	{
		if (newsItems.containsKey(id))
			newsItems.remove(id);
		else
			throw new UnknownIdException(id);
	}
	
	public String addNewsItem(NewsItem item)
	{
		String id = "" + nextId++;
		newsItems.put(id, item);
		return id;
	}
	
	public void replaceNewsItem(String id, NewsItem item)
	{
		if (newsItems.containsKey(id))
			newsItems.put(id, item);
		else
			throw new UnknownIdException(id);
	}
	

	
	public void print()
	{
		for (String eid: getNewsItemIds())
		{
			NewsItem item = getNewsItem(eid);
			System.out.println(item);
		}
	}
}
