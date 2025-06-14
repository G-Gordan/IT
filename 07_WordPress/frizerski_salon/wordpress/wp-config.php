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
define('DB_NAME', 'frizerski_salon');

/** MySQL database username */
define('DB_USER', 'root');

/** MySQL database password */
define('DB_PASSWORD', '');

/** MySQL hostname */
define('DB_HOST', 'localhost');

/** Database Charset to use in creating database tables. */
define('DB_CHARSET', 'utf8mb4');

/** The Database Collate type. Don't change this if in doubt. */
define('DB_COLLATE', '');

/**#@+
 * Authentication Unique Keys and Salts.
 *
 * Change these to different unique phrases!
 * You can generate these using the {@link https://api.wordpress.org/secret-key/1.1/salt/ WordPress.org secret-key service}
 * You can change these at any point in time to invalidate all existing cookies. This will force all users to have to log in again.
 *
 * @since 2.6.0
 */
define('AUTH_KEY',         '@5WV6O<6;sTAPk`Z#l9@ oMmE*VFgS/;JE|!*D(.:u60UG%_>A} l)e9N>L!fKsq');
define('SECURE_AUTH_KEY',  'wjDvPRD$yO WR]tY&5P_}A$mddh|y<l*-)9P-KY6n=>;|OFb9WXRNA>p9F|SscbF');
define('LOGGED_IN_KEY',    'Rs]GsL_9POa[qAAwIFkf&m@1+UwUkYM>xW+K3ZYy}q&nSzU7sD/[R1u*sx&Ze+_-');
define('NONCE_KEY',        '$|Tc0r<lQUr:XIx1zANYufr.fx[y{yP59q}bcKuquB 69W_mSViake>hIS,qSp.>');
define('AUTH_SALT',        'TQG^_LX:Zwio|k,b%89:B3M+!Lk/HGjNv[v|B-x0O0Btwhg)D<V$^YMwk~{p1z[=');
define('SECURE_AUTH_SALT', 'P,h36 D1AtZT86?ZJqpbw8|^.5Y])@&_r=`t[T{}C^cYAFXVJL`~w~#Lq:}X[G[G');
define('LOGGED_IN_SALT',   'n|1qS88ykW.cKWU&^p]<y{_,d#ZR<`dY_%}UgBgK8}/NiLz4kx&)?-rM%fXrp_&K');
define('NONCE_SALT',       '6nBt5<dE1B,KO+tB;cX9WAH(dsFTpS}SjzebOh!Pm :8gd8I}~zA<RaQyeG*[dil');

/**#@-*/

/**
 * WordPress Database Table prefix.
 *
 * You can have multiple installations in one database if you give each
 * a unique prefix. Only numbers, letters, and underscores please!
 */
$table_prefix  = 'wp_';

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
define('WP_DEBUG', false);

/* That's all, stop editing! Happy blogging. */

/** Absolute path to the WordPress directory. */
if ( !defined('ABSPATH') )
	define('ABSPATH', dirname(__FILE__) . '/');

/** Sets up WordPress vars and included files. */
require_once(ABSPATH . 'wp-settings.php');
