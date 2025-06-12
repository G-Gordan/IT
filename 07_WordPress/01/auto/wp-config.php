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
define( 'DB_NAME', 'test1' );

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
define( 'AUTH_KEY',         'lKtaAy5%<]0V/.+lpNP!fP=z4ASzkt6yv2Ld99X!Y_n$&FcW ;73wNfu%k0z8rWI' );
define( 'SECURE_AUTH_KEY',  'W3Q<1azd lLF e{}uLI_4nPO&s1-l&V@($0fmY5[GhB@66k/Z!syu|/k%*Km,pf{' );
define( 'LOGGED_IN_KEY',    'GGwA%eQ8nA=j3o0`vmpya)s{DnN.C8Z<3z>JJdb,4fcd3$x LgrG).!>kKdwMmYg' );
define( 'NONCE_KEY',        'uD^]_9ZEv*$;eP12_~$,]WU(^rX73!_cMRq!c6y E#`0 mB8.c,riq0i-}bBl,`q' );
define( 'AUTH_SALT',        'JDeM.6EU@MRGR!&J^ip9u, d?zo)v[x/ ;6_j/]@! zD*7p(zFX0b&v*E7X!!4zJ' );
define( 'SECURE_AUTH_SALT', '<XF g2geB9SQN2^Ll@=a#XDrSiF5l;r&ZdH=^AGP#Wx?e^;=cM2$i&Q-k?3$tPdW' );
define( 'LOGGED_IN_SALT',   '[|$d!x/_jZ@i1xlXJNoWLBfM9QlO^>q0U21U<*7tzfGAnIMMT&3./zZD]YR. d>?' );
define( 'NONCE_SALT',       'R)K/=92!{kLI_U0XZcVy}4xd!u+g7CO#.$Yn*Eku~pOaxMuDJ p[cej(`PBD)}y&' );

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
