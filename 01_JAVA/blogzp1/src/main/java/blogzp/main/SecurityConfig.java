package blogzp.main;

import javax.sql.DataSource;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Configuration;
import org.springframework.security.config.annotation.authentication.builders.AuthenticationManagerBuilder;
import org.springframework.security.config.annotation.web.builders.HttpSecurity;
import org.springframework.security.config.annotation.web.configuration.EnableWebSecurity;
import org.springframework.security.config.annotation.web.configuration.WebSecurityConfigurerAdapter;
import org.springframework.security.core.userdetails.User;
import org.springframework.security.core.userdetails.User.UserBuilder;

@Configuration
@EnableWebSecurity
public class SecurityConfig extends WebSecurityConfigurerAdapter {
	
	@Autowired
	private DataSource myDataSource;
	
	@Override
	protected void configure(AuthenticationManagerBuilder auth) throws Exception {
		/*
		UserBuilder user = User.withDefaultPasswordEncoder(); // privremeno koristimo...		
		auth.inMemoryAuthentication()
		.withUser(user.username("marko").password("marko123").roles("admin"))
		.withUser(user.username("jovanjovan").password("janko123").roles("bloger"));
		*/
		
		auth.jdbcAuthentication().dataSource(myDataSource);
		
	}
	
	@Override
	protected void configure(HttpSecurity http) throws Exception {
		/* bitan je REDOSLED zbrana */
		/* prvi red -> svi requestovi moraju biti autorizovani */
		/* drugi red -> svima je dozvoljen pristup svuda */
		/* od treceg reda -> definise ko gde ima pristup */
		http.authorizeRequests()
		.antMatchers("/").permitAll()
		.antMatchers("/admin/category-list").hasRole("admin")
		.antMatchers("/admin/category-form").hasRole("admin")
		.antMatchers("/admin/tag-form").hasRole("admin")
		.antMatchers("/admin/tag-list").hasRole("admin")
		.antMatchers("/admin/slideitem-form").hasRole("admin")
		.antMatchers("/admin/slideitem-list").hasRole("admin")
		.antMatchers("/admin/user-list").hasRole("admin")
		.antMatchers("/admin/**").hasAnyRole("bloger,admin")
		.and().formLogin()
		.loginPage("/loginPage")
		.loginProcessingUrl("/authenticateTheUser").permitAll();
		/* cetvrti red odpozedi -> ko ima pristup akcij: administration, ostalim pristupa samo: admin*/
		/* predzadnji red -> putanja (RequestMapping) do nase stranice (a ne defoltnog logina), akcija u kontroleru */
		// pezadnjiti red -> putanja akcije za proveru logovanje kad pritisnemo Submit
		//difoltna putanja Spring Security (on dalje kontrolise...)
		
	}

}
