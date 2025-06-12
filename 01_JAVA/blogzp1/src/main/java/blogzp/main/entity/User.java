package blogzp.main.entity;

import java.util.List;

import javax.persistence.CascadeType;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.FetchType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.JoinTable;
import javax.persistence.ManyToMany;
import javax.persistence.Table;

//@Entity
//@Table(name="users")
@Entity(name="users")
@Table
public class User {
	
	@Id
	@Column
	private String username;
	@Column
	private String password;
	@Column
	private String name;
	@Column
	private String surname;
	@Column
	private String email;
	@Column
	private String phone;
	@Column
	private String photo;
	@Column
	private boolean enabled;
	@JoinTable(name = "authorities",joinColumns = @JoinColumn(name = "username"),inverseJoinColumns = @JoinColumn(name = "authority"))
	@ManyToMany(cascade = {CascadeType.DETACH,CascadeType.MERGE,CascadeType.PERSIST,CascadeType.REFRESH}, fetch = FetchType.EAGER)
	private List<Role> authorities;
	
	public User() {

	}


	public User(String username, String password, boolean enabled, String name, String surname,
			String email, String phone, String photo, List<Role> authorities) {
		super();
		this.username = username;
		this.password = password;
		this.name = name;
		this.surname = surname;
		this.email = email;
		this.phone = phone;
		this.photo = photo;
		this.enabled = enabled;
		this.authorities = authorities;
	}

	
	public String getUsername() {
		return username;
	}

	public void setUsername(String username) {
		this.username = username;
	}
	public String getPassword() {
		return password;
	}
	public void setPassword(String password) {
		this.password = password;
	}

	public String getName() {
		return name;
	}
	public void setName(String name) {
		this.name = name;
	}
	public String getSurname() {
		return surname;
	}
	public void setSurname(String surname) {
		this.surname = surname;
	}
	
	public String getEmail() {
		return email;
	}
	public void setEmail(String email) {
		this.email = email;
	}
	public String getPhone() {
		return phone;
	}
	public void setPhone(String phone) {
		this.phone = phone;
	}
	public String getPhoto() {
		return photo;
	}
	public void setPhoto(String photo) {
		this.photo = photo;
	}
	
	public boolean getEnabled() {
		return enabled;
	}
	public void setEnabled(boolean enabled) {
		this.enabled = enabled;
	}

	public List<Role> getAuthorities() {
		return authorities;
	}
	public void setAuthorities(List<Role> authorities) {
		this.authorities = authorities;
	}
	
	@Override
	public String toString() {
		return name;
	}
	

}
