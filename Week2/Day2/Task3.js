const weatherDiv = document.getElementById("weather");

function getWeather() {
  fetch("https://api.open-meteo.com/v1/forecast?latitude=17.3850&longitude=78.4867&current_weather=true")
    .then(res => {
      if (!res.ok) {
        throw new Error("Failed to fetch weather data");
      }
      return res.json();
    })
    .then(data => {
      const { temperature, windspeed } = data.current_weather;

      weatherDiv.innerHTML = `
        <h3>Weather Report</h3>
        <p>🌡️ Temperature: ${temperature} °C</p>
        <p>💨 Wind Speed: ${windspeed} km/h</p>
      `;
    })
    .catch(error => {
      weatherDiv.innerHTML = `<p style="color:red;">${error.message}</p>`;
    });
}