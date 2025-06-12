<?php
add_action('after_setup_theme','gordan2_setup');
add_action('widgets_init','gordan2_dodaci');
add_action('widgets_init','gordan2_copyright');

function gordan2_setup() {
		add_theme_support( 'post-thumbnails' );
	
	$location = array(
		'primary'=>__('Primarna navigacija','gordan2'),
		'footer'=>__('Footer navigacija','gordan2'),
		'sidebar'=>__('Sidebar navigacija','gordan2'),
		'social'=>__('Social Group navigacija','gordan2'),
		);
	register_nav_menus($location);
}	
function gordan2_dodaci() {
	register_sidebar(
		array(
			'name'          => __( 'Pimarni Sidebar', 'gordan2' ),
			'id'            => 'footerbar1',
			'description'   => __( 'Ovde su widgeti za footer dodatke', 'gordan2' ),
			'before_widget' => '<section>',
			'after_widget'  => '</section>',
			'before_title'  => '<h2>',
			'after_title'   => '</h2>',
		)
	);
	
}

function gordan2_copyright() {
	register_sidebar(
		array(
			'name'          => __( 'Copyright Footer', 'gordan2' ),
			'id'            => 'copyright',
			'description'   => __( 'Ovde su widgeti za footer copyright', 'gordan2' ),
			'before_widget' => '<div>',
			'after_widget'  => '</div>',
			'before_title'  => '<h2>',
			'after_title'   => '</h2>',
		)
	);
	
}
