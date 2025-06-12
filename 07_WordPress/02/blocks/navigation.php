<!-- Nav -->
					<nav id="nav">
						<!-- Ovo su statičke navigacije koje preklapaju naše i zato ih isključujemo, da bi cod povezali sa navigacijom u WP-->
						<!--<ul class="links">
							<li class="active"><a href="index.html">This is Massively</a></li>
							<li><a href="generic.html">Generic Page</a></li>
							<li><a href="elements.html">Elements Reference</a></li>
						</ul>
						<ul class="icons">
							<li><a href="#" class="icon fa-twitter"><span class="label">Twitter</span></a></li>
							<li><a href="#" class="icon fa-facebook"><span class="label">Facebook</span></a></li>
							<li><a href="#" class="icon fa-instagram"><span class="label">Instagram</span></a></li>
							<li><a href="#" class="icon fa-github"><span class="label">GitHub</span></a></li>
						</ul>-->
					</nav>
					<?php 
					
					$args = array(
						'menu_class'=>'links',
						'container'=>'nav',
						'container_id'=>'nav',
						'theme_location'=>'primary'
					);	//postoji i container_class
						// primary se nalazi u fajlu functions u register_nav_menus funkciji u nizu 'Primarna navigacija','gordan2'
					wp_nav_menu($args) 
					
					?>