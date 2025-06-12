<?php
/**
 * About setup
 *
 * @package Magazine Prime
 */

if (!function_exists('magazine_prime_about_setup')):

/**
 * About setup.
 *
 * @since 1.0.0
 */
function magazine_prime_about_setup() {

	$config = array(

		// Welcome content.
		'welcome_content' => sprintf(esc_html__(' First off, We’d like to extend a warm welcome and thank you for choosing %1$s. %1$s is now installed and ready to use. We want to make sure you have the best experience using the theme and that is why we gathered here all the necessary information for you. Again, Thanks for using our theme!', 'magazine-prime'), 'Magazine Prime'),

		// Tabs.
		'tabs'             => array(
			'getting-started' => esc_html__('Getting Started', 'magazine-prime'),
			'support'         => esc_html__('Support', 'magazine-prime'),
			'useful-plugins'  => esc_html__('Useful Plugins', 'magazine-prime'),
			'demo-content'    => esc_html__('Demo Content', 'magazine-prime'),
		),

		// Quick links.
		'quick_links' => array(
			'theme_url'  => array(
				'text'      => esc_html__('Theme Details', 'magazine-prime'),
				'url'       => 'https://themeinwp.com/theme/magazine-prime/',
			),
			'demo_url' => array(
				'text'    => esc_html__('View Demo', 'magazine-prime'),
				'url'     => 'https://themeinwp.com/theme-demos/?demo=magazine-prime',
			),
			'documentation_url' => array(
				'text'             => esc_html__('View Documentation', 'magazine-prime'),
				'url'              => 'https://docs.themeinwp.com/themes/magazine-prime/',
				'button'           => 'primary',
			),
		),

		// Getting started.
		'getting_started' => array(
			'one'            => array(
				'title'         => esc_html__('Theme Documentation', 'magazine-prime'),
				'icon'          => 'dashicons dashicons-format-aside',
				'description'   => esc_html__('Please check our full documentation for detailed information on how to setup and customize the theme.', 'magazine-prime'),
				'button_text'   => esc_html__('View Documentation', 'magazine-prime'),
				'button_url'    => 'https://docs.themeinwp.com/themes/magazine-prime/',
				'button_type'   => 'primary',
				'is_new_tab'    => true,
			),
			'two'          => array(
				'title'       => esc_html__('Static Front Page', 'magazine-prime'),
				'icon'        => 'dashicons dashicons-admin-generic',
				'description' => esc_html__('To achieve custom home page other than blog listing, you need to create and set static front page.', 'magazine-prime'),
				'button_text' => esc_html__('Static Front Page', 'magazine-prime'),
				'button_url'  => admin_url('customize.php?autofocus[section]=static_front_page'),
				'button_type' => 'primary',
			),
			'three'        => array(
				'title'       => esc_html__('Theme Options', 'magazine-prime'),
				'icon'        => 'dashicons dashicons-admin-customizer',
				'description' => esc_html__('Theme uses Customizer API for theme options. Using the Customizer you can easily customize different aspects of the theme.', 'magazine-prime'),
				'button_text' => esc_html__('Customize', 'magazine-prime'),
				'button_url'  => wp_customize_url(),
				'button_type' => 'primary',
			),
			'four'         => array(
				'title'       => esc_html__('Widget Ready', 'magazine-prime'),
				'icon'        => 'dashicons dashicons-admin-settings',
				'description' => esc_html__('Magazine Prime is widget based Theme. Magazine Prime has 7 predesigned custome additional layout.', 'magazine-prime'),
				'button_text' => esc_html__('View Widgets', 'magazine-prime'),
				'button_url'  => admin_url('widgets.php'),
				'button_type' => 'secondary',
			),
			'five'         => array(
				'title'       => esc_html__('Demo Content', 'magazine-prime'),
				'icon'        => 'dashicons dashicons-layout',
				'description' => sprintf(esc_html__('%1$s plugin should be installed and activated. After plugin is activated, visit Import Demo Data menu under Appearance.', 'magazine-prime'), esc_html__('One Click Demo Import', 'magazine-prime')),
				'button_text' => esc_html__('Demo Content', 'magazine-prime'),
				'button_url'  => admin_url('themes.php?page=magazine-prime-about&tab=demo-content'),
				'button_type' => 'secondary',
			),
			'six'          => array(
				'title'       => esc_html__('Theme Preview', 'magazine-prime'),
				'icon'        => 'dashicons dashicons-welcome-view-site',
				'description' => esc_html__('You can check out the theme demos for reference to find out what you can achieve using the theme and how it can be customized.', 'magazine-prime'),
				'button_text' => esc_html__('View Demo', 'magazine-prime'),
				'button_url'  => 'https://themeinwp.com/theme-demos/?demo=magazine-prime',
				'button_type' => 'secondary',
				'is_new_tab'  => true,
			),
		),

		// Support.
		'support'       => array(
			'one'          => array(
				'title'       => esc_html__('Contact Support', 'magazine-prime'),
				'icon'        => 'dashicons dashicons-sos',
				'description' => esc_html__('Got theme support question or found bug or got some feedbacks? Best place to ask your query is the dedicated Support forum for the theme.', 'magazine-prime'),
				'button_text' => esc_html__('Contact Support', 'magazine-prime'),
				'button_url'  => 'https://wordpress.org/support/theme/magazine-prime/',
				'button_type' => 'secondary',
				'is_new_tab'  => true,
			),
			'two'          => array(
				'title'       => esc_html__('Theme Documentation', 'magazine-prime'),
				'icon'        => 'dashicons dashicons-format-aside',
				'description' => esc_html__('Please check our full documentation for detailed information on how to setup and customize the theme.', 'magazine-prime'),
				'button_text' => esc_html__('View Documentation', 'magazine-prime'),
				'button_url'  => 'https://docs.themeinwp.com/themes/magazine-prime/',
				'button_type' => 'secondary',
				'is_new_tab'  => true,
			),
			'three'        => array(
				'title'       => esc_html__('Child Theme', 'magazine-prime'),
				'icon'        => 'dashicons dashicons-admin-tools',
				'description' => esc_html__('For advanced theme customization, it is recommended to use child theme rather than modifying the theme file itself.', 'magazine-prime'),
				'button_text' => esc_html__('Learn More', 'magazine-prime'),
				'button_url'  => 'https://developer.wordpress.org/themes/advanced-topics/child-themes/',
				'button_type' => 'secondary',
				'is_new_tab'  => true,
			),
		),

		// Useful plugins.
		'useful_plugins' => array(
			'description'   => esc_html__('Theme supports some helpful WordPress plugins to enhance your site. But, please enable only those plugins which you need in your site. For example, enable WooCommerce only if you are using e-commerce.', 'magazine-prime'),
		),

		// Demo content.
		'demo_content' => array(
			'description' => sprintf(esc_html__('To import demo content for this theme, %1$s plugin is needed. Please make sure plugin is installed and activated. After plugin is activated, you will see Import Demo Data menu under Appearance.', 'magazine-prime'), '<a href="https://wordpress.org/plugins/one-click-demo-import/" target="_blank">'.esc_html__('One Click Demo Import', 'magazine-prime').'</a>'),
		),

		// Upgrade to pro.
		'upgrade_to_pro' => array(
			'description'   => esc_html__('You can upgrade to pro version of the theme for more exciting features.', 'magazine-prime'),
			'button_text'   => esc_html__('Upgrade to Pro', 'magazine-prime'),
			'button_url'    => 'https://themeinwp.com/theme/magazine-prime/',
			'button_type'   => 'primary',
			'is_new_tab'    => true,
		),
	);

	Magazine_Prime_About::init($config);
}

endif;

add_action('after_setup_theme', 'magazine_prime_about_setup');
