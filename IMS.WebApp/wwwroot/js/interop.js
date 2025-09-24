// Toasts for user actions

window.showAddSuccessful = () => {
    console.log("CLICKED")
    const toastLiveExample = document.getElementById('liveToast');
    const toastBody = document.getElementById('toast-body');
    const btnElm = document.getElementById('close-add-modal');
    if (toastLiveExample && toastBody) {
        toastBody.innerText = "✅ Add complete!";
        const toastBootstrap = bootstrap.Toast.getOrCreateInstance(toastLiveExample);
        toastBootstrap.show();
        btnElm.click();
    }
};

window.showEditSuccessful = () => {
    const toastLiveExample = document.getElementById('liveToast');
    const toastBody = document.getElementById('toast-body');
    const btnElm = document.getElementById('close-edit-modal');
    if (toastLiveExample && toastBody) {
        toastBody.innerText = "✏️ Edit successful!";
        const toastBootstrap = bootstrap.Toast.getOrCreateInstance(toastLiveExample);
        toastBootstrap.show();
        btnElm.click();
    }
};

window.showDeleteSuccessful = () => {
    const toastLiveExample = document.getElementById('liveToast');
    const toastBody = document.getElementById('toast-body');
    if (toastLiveExample && toastBody) {
        toastBody.innerText = "🗑️ Delete successful!";
        const toastBootstrap = bootstrap.Toast.getOrCreateInstance(toastLiveExample);
        toastBootstrap.show();
    }
};

window.showErrorToast = () => {
    const toastLiveExample = document.getElementById('liveToast');
    const toastBody = document.getElementById('toast-body');
    if (toastLiveExample && toastBody) {
        toastBody.innerText = "❌ Something went wrong!";
        const toastBootstrap = bootstrap.Toast.getOrCreateInstance(toastLiveExample);
        toastBootstrap.show();
    }
}


