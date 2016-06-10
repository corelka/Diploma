/*
This file in the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

//var gulp = require('gulp');

//gulp.task('default', function () {
//    // place code for your default task here
//});

/// <binding Clean='clean' />
"use strict";

var gulp = require("gulp"),
    rimraf = require("rimraf"),
    less = require("gulp-less"); // добавляем модуль less

var paths = {
    webroot: "./wwwroot/"
};
//  регистрируем задачу по преобразованию styles.less в файл css
gulp.task("less", function () {
    return gulp.src(paths.webroot+'less/menu.less')
            .pipe(less())
            .pipe(gulp.dest(paths.webroot + '/stylesheet'))
});