const connect = () =>
	fetch("game/connect",
		{
			"body": null,
			"method": "POST",
			"mode": "cors"
		})
		.then(response => response.json());

const getPlayroomState = (roomId) =>
	fetch("game/room/" + roomId,
		{
			"method": "GET",
			"mode": "cors"
		})
		.then(response => response.json());

const sendReport = (shakeReport) =>
	fetch("/game/report",
		{
			"body": JSON.stringify(shakeReport),
			"headers": { "content-type": "application/json-patch+json" },
			"method": "POST",
			"mode": "cors"
		});
