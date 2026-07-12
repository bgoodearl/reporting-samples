/*
This file in the main entry point for defining Gulp tasks and using Gulp plugins.
*/
{
	const { dest, series, src, task } = require('gulp');
	//const gdb = import('gulp-debug');
	//const { debug } = require('gulp-debug');
	console.log('gulpefile - vx.x');

  // Error handling
  //
  var onError = function (err) {
      notify.onError({
          title: "Gulp",
          subtitle: "Houston, we have a problem!",
          message: "Error: <%= error.message %>",
          sound: "Beep"
      })(err);
      this.emit('end');
  }

	function clean(cb) {
	  // body omitted
	  cb();
	}
	function defaultTask(cb) {
		copy3rdPartyMinCss();
		cb();
	}

	task('copy3rdPartyMinCss', function () {
		var npmThirdPartyCssMinFiles = [
			'ClientApp/node_modules/bootstrap/dist/css/bootstrap.min.css'
		];
		return src(npmThirdPartyCssMinFiles)
			//.pipe(debug({title: '3pcssmn:'}))
			.pipe(dest('wwwroot/css2'));
	});

	task('copy3rdPartyMinJs', function () {
		var npmThirdPartyJsMinFiles = [
			'ClientApp/node_modules/bootstrap/dist/js/bootstrap.bundle.min.js',
			'ClientApp/node_modules/jquery/dist/jquery.min.js'
		];
		return src(npmThirdPartyJsMinFiles)
			//.pipe(debug({title: '3pcsmnJs:'}))
			.pipe(dest('wwwroot/js2'));
	});
	
	exports.default = series(clean, defaultTask);
}