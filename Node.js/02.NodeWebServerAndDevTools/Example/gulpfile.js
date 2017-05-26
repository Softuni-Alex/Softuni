let gulp = require('gulp')
let del = require('del')
let uglify = require('gulp-uglify')
let concat = require('gulp-concat')

gulp.task('scripts',() =>{
    del.sync(['build/alljs*'])

    return gulp.src([
        'content/site.js',
        'content/libs/jquery/dist/jquery.js'
    ])
    .pipe(uglify())
    .pipe(concat('alljs.min.js'))
    .pipe(gulp.dest('build'))
})