/// <binding BeforeBuild='sass' />
var gulp = require('gulp'),
    sass = require('gulp-sass');

gulp.task('site-sass', function() {
    return gulp.src(['./Sass/site.scss', './Sass/layout.scss'])
      .pipe(sass())
      .pipe(gulp.dest('./wwwroot/css'));
});

gulp.task('customizations-sass', function() {
    return gulp.src('./Sass/customizations.scss')
      .pipe(sass())
      .pipe(gulp.dest('./templates'));
});

gulp.task('other-sass', function() {
    return gulp.src('./Sass/**/*.scss')
      .pipe(sass())
      .pipe(gulp.dest('./wwwroot/css'));
});

gulp.task('sass', ['site-sass', 'other-sass', 'customizations-sass']);