/// <binding AfterBuild='dev-bundle' Clean='dev-clean-bundle' ProjectOpened='dev-watch-bundle' />
/*
This file is the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp');
var concat = require('gulp-concat');
var del = require('del');
var watch = require('gulp-watch');

var paths = {
	transpiled: [
		'transpiled/**/*.js',
		'transpiled/**/*.map'],
	libs: [
		'node_modules/linq/linq.min.js'
	],
	typescript: ['scripts/**/*.ts'],
	pages: ['pages/**/*.html'],
	styles: ['styles/*'],
	images: ['images/*']
};

var watchPaths = []
	.concat(paths.transpiled)
	.concat(paths.typescript)
	.concat(paths.libs)
	.concat(paths.pages)
	.concat(paths.styles)
	.concat(paths.images);

gulp.task('dev-clean-bundle', function () {
	return	del(['bundle-dev/*']);
});

function moveAll() {
	gulp.src(paths.typescript).pipe(gulp.dest('bundle-dev/scripts'));
	gulp.src(paths.transpiled).pipe(gulp.dest('bundle-dev/scripts'));
	gulp.src(paths.pages).pipe(gulp.dest('bundle-dev'));
	gulp.src(paths.styles).pipe(gulp.dest('bundle-dev'));
	gulp.src(paths.images).pipe(gulp.dest('bundle-dev/images'));
	gulp.src(paths.libs).pipe(gulp.dest('bundle-dev/libs'));
}

gulp.task('dev-bundle', function () {
	// wait for all files to build before bundling
	setTimeout(function() {
		moveAll();
	}, 200);
});

gulp.task('dev-watch-bundle', function () {
    gulp.watch(watchPaths, ['dev-clean-bundle', 'dev-bundle']);
});