window.fbAsyncInit = function () {
	FB.init({
		appId: '488933895322331',
		cookie: true,
		xfbml: true,
		version: 'v6.0'
	});

	FB.AppEvents.logPageView();
};

function statusChangeCallback(loginStatus) {
	if (loginStatus.status === "connected") { // if login succeeded
		var auth = loginStatus.authResponse;
		state.auth = auth;
	}
}

function checkLoginState() {
	FB.getLoginStatus(function (response) {
		statusChangeCallback(response);
	});
}

function getUserImage(userId, accessToken) {
	return fetch(
		"https://graph.facebook.com/v6.0/" + userId + "/picture?access_token=" + accessToken + "&debug=all&format=json&method=get&pretty=0&redirect=false&suppress_http_code=1&transport=cors",
		{
			"credentials": "omit",
			"headers": {
				"accept": "*/*",
				"cache-control": "no-cache",
				"content-type": "application/x-www-form-urlencoded",
				"pragma": "no-cache",
				"sec-fetch-dest": "empty",
				"sec-fetch-mode": "cors",
				"sec-fetch-site": "same-site"
			},
			"method": "GET",
			"mode": "cors"
		})
		.then(r => r.json());
}

(function (d, s, id) {
	var js, fjs = d.getElementsByTagName(s)[0];
	if (d.getElementById(id)) { return; }
	js = d.createElement(s); js.id = id;
	js.src = "https://connect.facebook.net/en_US/sdk.js";
	fjs.parentNode.insertBefore(js, fjs);
}(document, 'script', 'facebook-jssdk'));
