package model;

/**
 * @author wijnand.schepens@hogent.be
 */
public class UnknownIdException extends RuntimeException
{
	public UnknownIdException(String id)
	{
		super("unknown id '" + id + "'");
	}
}
