<?php
/**
 * Displays footer instagram widget
 *
 * @package Euphony
 */
?>

<?php
if ( class_exists( 'A_Music_Theme_Audio_Widget' ) ) :
	if ( is_active_sidebar( 'sidebar-audio' ) ) :
	?>
	<aside id="header-audio" class="widget-area section" role="complementary">
		<div class="wrapper">
			<?php dynamic_sidebar( 'sidebar-audio' ); ?>
		</div><!-- .wrapper -->
	</aside><!-- .widget-area -->
	<?php endif;
endif;
