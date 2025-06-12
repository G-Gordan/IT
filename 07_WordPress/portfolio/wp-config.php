<?php
/**
 * The base configuration for WordPress
 *
 * The wp-config.php creation script uses this file during the
 * installation. You don't have to use the web site, you can
 * copy this file to "wp-config.php" and fill in the values.
 *
 * This file contains the following configurations:
 *
 * * MySQL settings
 * * Secret keys
 * * Database table prefix
 * * ABSPATH
 *
 * @link https://codex.wordpress.org/Editing_wp-config.php
 *
 * @package WordPress
 */

// ** MySQL settings - You can get this info from your web host ** //
/** The name of the database for WordPress */
define( 'DB_NAME', 'cv' );

/** MySQL database username */
define( 'DB_USER', 'root' );

/** MySQL database password */
define( 'DB_PASSWORD', '' );

/** MySQL hostname */
define( 'DB_HOST', 'localhost' );

/** Database Charset to use in creating database tables. */
define( 'DB_CHARSET', 'utf8mb4' );

/** The Database Collate type. Don't change this if in doubt. */
define( 'DB_COLLATE', '' );

/**#@+
 * Authentication Unique Keys and Salts.
 *
 * Change these to different unique phrases!
 * You can generate these using the {@link https://api.wordpress.org/secret-key/1.1/salt/ WordPress.org secret-key service}
 * You can change these at any point in time to invalidate all existing cookies. This will force all users to have to log in again.
 *
 * @since 2.6.0
 */
define( 'AUTH_KEY',         '<A+R]czXB,I60O-;3>%vh|md(OontLXO_FMvl.oiv/(AnOW>B/UbpIT:50|jIVA;' );
define( 'SECURE_AUTH_KEY',  '&t:Xh-C>:;E1Ypyj=d|m4Q]n]x$cZcn9E4<0btCjop{7xvF+iwc.n o**j<49NkJ' );
define( 'LOGGED_IN_KEY',    '+ep4)avfc~:1d`?nUQrtL*!|v]Y2Na:9 ~fE(<?+kS]Tx@rZ3fw/-x.|Xg,qz4)[' );
define( 'NONCE_KEY',        'k,Jt <c!&X=]ZT>J8j_[z]9D3MQnqiQfJRQ/fPmLbSFZg0T6^u$F Ais62zeB,Al' );
define( 'AUTH_SALT',        'Es.XfLOW[q1x|]I]rbyK[P0ulu{1w:<l=W:).8{m@Iy/4!p`j4k,,SI{yNX:mV=.' );
define( 'SECURE_AUTH_SALT', '_Xy,V(<r! 4kb-p6?/;!xi15vMx44949Ev8DlUM8%AW&K.* h4`O/2%%{/f4>8rI' );
define( 'LOGGED_IN_SALT',   'SN$(=r9`r_Jk!ngV9}&tTARy@-:(i73SMUGihSbrMrO9u[Yen`n%yeEk$!79yw(}' );
define( 'NONCE_SALT',       'Sg|:mF:U`A3qI{u 9Wv`[fjRlxGXan.mme)yNv|BgK:Kq1!|&D{#rB+5Oa{O_6||' );

/**#@-*/

/**
 * WordPress Database Table prefix.
 *
 * You can have multiple installations in one database if you give each
 * a unique prefix. Only numbers, letters, and underscores please!
 */
$table_prefix = 'wp_';

/**
 * For developers: WordPress debugging mode.
 *
 * Change this to true to enable the display of notices during development.
 * It is strongly recommended that plugin and theme developers use WP_DEBUG
 * in their development environments.
 *
 * For information on other constants that can be used for debugging,
 * visit the Codex.
 *
 * @link https://codex.wordpress.org/Debugging_in_WordPress
 */
define( 'WP_DEBUG', false );

/* That's all, stop editing! Happy publishing. */

/** Absolute path to the WordPress directory. */
if ( ! defined( 'ABSPATH' ) ) {
	define( 'ABSPATH', dirname( __FILE__ ) . '/' );
}

/** Sets up WordPress vars and included files. */
require_once( ABSPATH . 'wp-settings.php' );
