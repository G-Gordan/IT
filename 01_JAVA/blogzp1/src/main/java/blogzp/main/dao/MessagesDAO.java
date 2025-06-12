package blogzp.main.dao;

import java.util.List;

import blogzp.main.entity.Messages;

public interface MessagesDAO {
	
	// daje jednu message po prosledjenom id-ju
	public Messages getMessage(int id);
	// daje listu svih poruka
	public List<Messages> getMessagesList();
	// cuva message
	public void saveMessage(Messages messages);
	// brisanje zadate porukea
	public void deleteMessage(int id);
	// daje messages cekirane da su procitane
	public List<Messages> getMessagesIsSeen();
	// broji nepregledane poruke
	public long getUnreadMessagesCount();

}
