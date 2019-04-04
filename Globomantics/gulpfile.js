/// <binding Clean='clean' />
"use strict";

var gulp = require("gulp"),
    concat = require("gulp-concat"),
    cssmin = require("gulp-cssmin"),
    uglify = require("gulp-uglify");

gulp.task("min:js", function () {
    //return gulp.src([paths.jqueryJs, paths.raphaelJs, paths.morrisJs])
    //    .pipe(concat(paths.jsDest + "min.site.min.js"))
    //    .pipe(ugligy())
    //    .pipe(gulp.dest("."));
    return null;
});

gulp.task("copy:js", function() {
    return gulp.src([paths.jqueryJs, paths.raphaelJs, paths.morrisJs])
        .pipe(gulp.dest(paths.jsDest));
});

gulp.task("min:css", function() {
    return gulp.src([paths.BootstrapCss, paths.sbAdminCss, paths.fontAwesomeCss, paths.morrisJs])
        .pipe(concat(paths.cssDest + "/min/site.min.css"))
        .pipe(cssmin())
        .pipe(gulp.dest("."));
});