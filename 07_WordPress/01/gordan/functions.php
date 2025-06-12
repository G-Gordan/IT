<?php
add_action('after_setup_theme','gordan_setup');
add_action('widgets_init','gordan_dodaci');

function gordan_setup() {
	//ovo postavlja featured images
	add_theme_support( 'post-thumbnails' );
	
	// ovo dodaje funkcionalnost menija kroz promenljivu $location
	
	$location = array(
	//primary je lokacija, __ ove dve donje crte su funkcija za prevodivost stringa a gordan (drugi argument metode je text domein) i
	//aktivira prevod ako je aktivna tema gordan - DUPLIRANJE REDA U Notpade++ -> stanema na kraj reda i Ctrl+D
	//ove lokacije se pojavljuju u Dashboard/Appearence/Menu
		'primary'=>__('Glavna navigacija','gordan'),
		'footer'=>__('Footer navigacija','gordan'),
		'sidebar'=>__('Sidebar navigacija','gordan'),
		'social'=>__('Social navigacija','gordan'),
		);
	//register - pokreće funkcionalnost
	register_nav_menus($location);
}	
	//vidžet funkcija kojoj možemo da promenimo ime, ali prvi deo mora biti text domen teme (ime teme): function twentyseventeen_widgets_init()
function gordan_dodaci() {
	register_sidebar(
		array(
			//vidžetafija u sidebaru
			'name'          => __( 'Prvi Sidebar', 'gordan' ),
			'id'            => 'sidebar-1',
			'description'   => __( 'Dodajte ovde widgete za vaš sidebar na pst blogui aktivnim stranicama.', 'gordan' ),
			//vidžeti u frontu, da li postoji nešto što okružuje svaki vidžet
			/*'before_widget' => '<section id="%1$s" class="widget %2$s">',
			'after_widget'  => '</section>',
			'before_title'  => '<h2 class="widget-title">',
			'after_title'   => '</h2>',*/
			'before_widget' => '<div">',
			'after_widget'  => '</div>',
			'before_title'  => '<h2>',
			'after_title'   => '</h2>',
		)
	);
	
}

