﻿'use strict';

module.exports = {

	changeImage: function () {

		$("[membership-level-btn]").on("click", function () {
			const $this = $(this);
			const itemKey = $this.data("item");
			const $item = $("[data-item=" + itemKey + "]");
			let headerHeight = $('.header').height();

			if (!$item) return;
			$item.siblings("[data-item]").hide();
			$item.show();

			// Set Athlete status for become-member-form
			$("#Status").val("");
			const status = $this.data("status");

			if (!status) return;
			$("#Status").val(status);

			if ($(window).width() < 1025) {
				$('html, body').animate({
					scrollTop: $(".payment-img:visible").offset().top - headerHeight
				}, 500);
			}
		});
	},

	validatorSkip: function () {
		const $this = $("#become-member-form").data("validator");
		if (!$this) return;

		$this.settings.ignore = "";
	},

	changeBtn: function() {
		const $btn = $('.box-bottom-btn .btn');

		$btn.on('click', function() {
			$(this).css({
				'background-color': '#fff',
				'color': '#e51018',
				'border-color': '#e51018'
			});
			$(this).closest('.sw-mem-lvl-box').siblings().find('.btn').css({
				'background-color': '#e51018',
				'color': '#fff'
			});
		});
	}
};

// E-mail address validation
jQuery.validator.unobtrusive.adapters.add("emailcustom", ["emailregex"], function (options) {
	options.rules["emailcustom"] = { emailregex: options.params.emailregex };
	if (options.message) {
		options.messages["emailcustom"] = options.message;
	}
});

jQuery.validator.addMethod("emailcustom", function (value, element, param) {
	if (value === "") return true;

	const regex = new RegExp(param.emailregex);

	return regex.test(value);
});

// Image extension validation
jQuery.validator.unobtrusive.adapters.add("imagevalid", ["imageregex"], function (options) {
	options.rules["imagevalid"] = { imageregex: options.params.imageregex };
	if (options.message) {
		options.messages["imagevalid"] = options.message;
	}
});

jQuery.validator.addMethod("imagevalid", function (value, element, param) {
	if (value === "") return true;

	const regex = new RegExp(param.imageregex);

	return regex.test(value);
});

// Image file size validation
jQuery.validator.unobtrusive.adapters.add('filesize', ['maxsize'], function (options) {
	// Set up test parameters
	var params = {
		maxsize: options.params.maxsize
	};

	// Match parameters to the method to execute
	options.rules['filesize'] = params;
	if (options.message) {
		// If there is a message, set it for the rule
		options.messages['filesize'] = options.message;
	}
});

jQuery.validator.addMethod("filesize", function (value, element, param) {
	if (value === "") {
		// no file supplied
		return true;
	}

	var maxBytes = parseInt(param.maxsize);

	// use HTML5 File API to check selected file size

	if (element.files !== undefined && element.files[0] !== undefined && element.files[0].size !== undefined) {
		var filesize = parseInt(element.files[0].size);

		return filesize <= maxBytes;
	}

	// if the browser doesn't support the HTML5 file API, just return true
	// since returning false would prevent submitting the form 
	return true;
});