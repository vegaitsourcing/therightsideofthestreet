'use strict';

module.exports = {

	subscribe: function () {

		$(".newsletter-submit").on("click", function (e) {			

			const error = $("span#EmailAddress-error").text();
			if (error) return;
			const controllerUrl = $(this).data("controller-url");
			const emailAddress = $(this).siblings('input').val();
			if (!emailAddress) return;
			e.preventDefault();
			$.post(controllerUrl, { emailAddress: emailAddress }, function (response) {
				$('.newsletter-form .wrap').empty();
				$('.newsletter-form .wrap').append("<h2 class='centered color-white'>" + response + "</h2>");
			}, 'html');

		});

		$("[footer-submit]").on("click", function (e) {			
			const error = $("span#NewsLetter_EmailAddress-error").text();
			if (error) return;

			const controllerUrl = $(this).data("controller-url");
			const emailAddress = $(this).siblings('input').val();

			if (!emailAddress) return;
			e.preventDefault();
			$.post(controllerUrl, { emailAddress: emailAddress }, function (response) {
				$('.newsletter .newsletter-form').empty();
				$('.newsletter .newsletter-form').append("<h1 class='h3'>" + response + "</h2>");
			}, 'html');

		});
	}
};