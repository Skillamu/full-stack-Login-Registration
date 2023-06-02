viewHandler();

function viewHandler() {
    if (model.currentView === "register") registerView();

    else if (model.currentView === "login") loginView();

    else if (model.currentView === "homepage") homePageView();
};