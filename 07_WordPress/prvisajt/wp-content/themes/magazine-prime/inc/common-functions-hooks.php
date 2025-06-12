<?php
if (!function_exists('magazine_prime_the_custom_logo')):
/**
 * Displays the optional custom logo.
 *
 * Does nothing if the custom logo is not available.
 *
 * @since magazine-prime 1.0.0
 */
function magazine_prime_the_custom_logo() {
	if (function_exists('the_custom_logo')) {
		the_custom_logo();
	}
}
endif;

if (!function_exists('magazine_prime_body_class')):

/**
 * body class.
 *
 * @since 1.0.0
 */
function magazine_prime_body_class($magazine_prime_body_class) {
	global $post;
	$global_layout       = magazine_prime_get_option('global_layout');
	$input               = '';
	$home_content_status = magazine_prime_get_option('home_page_content_status');
	if (1 != $home_content_status) {
		$input = 'home-content-not-enabled';
	}
	// Check if single.
	if ($post && is_singular()) {
		$post_options = get_post_meta($post->ID, 'magazine-prime-meta-select-layout', true);
		if (empty($post_options)) {
			$global_layout = esc_attr(magazine_prime_get_option('global_layout'));
		} else {
			$global_layout = esc_attr($post_options);
		}
	}
	if ($global_layout == 'left-sidebar') {
		$magazine_prime_body_class[] = 'left-sidebar '.esc_attr($input);
	} elseif ($global_layout == 'no-sidebar') {
		$magazine_prime_body_class[] = 'no-sidebar '.esc_attr($input);
	} else {
		$magazine_prime_body_class[] = 'right-sidebar '.esc_attr($input);

	}
	return $magazine_prime_body_class;
}
endif;

add_action('body_class', 'magazine_prime_body_class');
/**
 * Returns word count of the sentences.
 *
 * @since magazine-prime 1.0.0
 */
if (!function_exists('magazine_prime_words_count')):
function magazine_prime_words_count($length = 25, $magazine_prime_content = null) {
	$length          = absint($length);
	$source_content  = preg_replace('`\[[^\]]*\]`', '', $magazine_prime_content);
	$trimmed_content = wp_trim_words($source_content, $length, '...');
	return $trimmed_content;
}
endif;

if (!function_exists('magazine_prime_simple_breadcrumb')):

/**
 * Simple breadcrumb.
 *
 * @since 1.0.0
 */
function magazine_prime_simple_breadcrumb() {

	if (!function_exists('breadcrumb_trail')) {

		require_once get_template_directory().'/assets/libraries/breadcrumbs/breadcrumbs.php';
	}

	$breadcrumb_args = array(
		'container'   => 'div',
		'show_browse' => false,
	);
	breadcrumb_trail($breadcrumb_args);

}

endif;

if (!function_exists('magazine_prime_custom_posts_navigation')):
/**
 * Posts navigation.
 *
 * @since 1.0.0
 */
function magazine_prime_custom_posts_navigation() {

	$pagination_type = magazine_prime_get_option('pagination_type');

	switch ($pagination_type) {

		case 'default':
			the_posts_navigation();
			break;

		case 'numeric':
			the_posts_pagination();
			break;

		default:
			break;
	}

}
endif;

add_action('magazine_prime_action_posts_navigation', 'magazine_prime_custom_posts_navigation');

if (!function_exists('magazine_prime_excerpt_length') && !is_admin()):

/**
 * Excerpt length
 *
 * @since  magazine-prime 1.0.0
 *
 * @param null
 * @return int
 */
function magazine_prime_excerpt_length($length) {
	global $magazine_prime_customizer_all_values;
	$excerpt_length = $magazine_prime_customizer_all_values['excerpt_length_global'];
	if (empty($excerpt_length)) {
		$excerpt_length = $length;
	}
	return absint($excerpt_length);

}

endif;
add_filter('excerpt_length', 'magazine_prime_excerpt_length', 999);

if (!function_exists('magazine_prime_recommended_plugins')):

/**
 * Recommended plugins
 *
 */
function magazine_prime_recommended_plugins() {
	$magazine_prime_plugins = array(
		array(
			'name'     => __('One Click Demo Import', 'magazine-prime'),
			'slug'     => 'one-click-demo-import',
			'required' => false,
		)
	);
	$magazine_prime_plugins_config = array(
		'dismissable' => true,
	);

	tgmpa($magazine_prime_plugins, $magazine_prime_plugins_config);
}
endif;
add_action('tgmpa_register', 'magazine_prime_recommended_plugins');

// Disable PT branding.
add_filter('pt-ocdi/disable_pt_branding', '__return_true');

function magazine_prime_ocdi_after_import() {
	// Assign menus to their locations.
	$main_menu   = get_term_by('name', 'Primary', 'nav_menu');
	$footer_menu = get_term_by('name', 'topbar', 'nav_menu');
	$social_menu = get_term_by('name', 'Social', 'nav_menu');

	set_theme_mod('nav_menu_locations', array(
			'primary' => $main_menu->term_id,
			'top'     => $footer_menu->term_id,
			'social'  => $social_menu->term_id,
		)
	);

	// Assign front page and posts page (blog page).
	$front_page_id = get_page_by_title('Home');
	$blog_page_id  = get_page_by_title('Blog');

	update_option('show_on_front', 'page');
	update_option('page_on_front', $front_page_id->ID);
	update_option('page_for_posts', $blog_page_id->ID);

}
add_action('pt-ocdi/after_import', 'magazine_prime_ocdi_after_import');
