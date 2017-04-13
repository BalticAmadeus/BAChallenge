var gulp = require('gulp');
var inject = require('gulp-inject');
var webserver = require('gulp-webserver');
 
gulp.task('inject-css',function() {
 
    var target = gulp.src('./client/index.html');
 
    return target.pipe(inject(gulp.src('./client/css/main.css', { read: false }),{ignorePath: 'client', addRootSlash: false}))
        .pipe(gulp.dest('./client/'));
});
 
gulp.task('inject-js', function() {
    var target = gulp.src('./client/index.html');
 
  return target.pipe(inject(gulp.src(['./client/app/events.module.js','./client/app/**/*.js'], {read: false}), {ignorePath: 'client', addRootSlash: false}))
    .pipe(gulp.dest('./client/'));
});
 
gulp.task('webserver', function() {
  gulp.src('./client/')
    .pipe(webserver({
      livereload: true,
      open: true,
      fallback: 'index.html'
    }));
});
 
gulp.task('watch', function() {
  gulp.watch(['client/css/*.css','client/app/**/*.js'], ['build-dev']);
});
 
gulp.task('serve-dev', ['build-dev','webserver' ,'watch']);
 
gulp.task('build-dev', ['inject-css','inject-js']);
gulp.task('default', ['serve-dev']);