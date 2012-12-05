/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package dao;

import java.util.Map;
import model.Concert;

/**
 *
 * @author Ah Lun Tang
 */
public interface IConcertDAO {
    public Map<Long, Concert> getAlleConcerten();
    public Concert getConcert(long concertid);
}
