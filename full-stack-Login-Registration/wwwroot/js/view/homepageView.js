function homePageView() {
    const app = document.getElementById("app");

    app.innerHTML = `
    <h2>Homepage</h2>

    <p>Have a good day, ${model.loggedInUser} :).</p>
    `
}
