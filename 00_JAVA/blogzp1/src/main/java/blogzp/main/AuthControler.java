package blogzp.main;

import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;

@Controller
public class AuthControler {
	
	@RequestMapping("/loginPage")
	public String getLoginPage() {
		
		return "/loginPage";
	}

}
