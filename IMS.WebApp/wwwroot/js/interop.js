// Toasts for user actions

window.showAddSuccessful = () => {
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

window.showSaveSuccessful = () => {
    const toastLiveExample = document.getElementById('liveToast');
    const toastBody = document.getElementById('toast-body');
    const btnElm = document.getElementById('close-add-modal');
    if (toastLiveExample && toastBody) {
        toastBody.innerText = "✅ Save complete!";
        const toastBootstrap = bootstrap.Toast.getOrCreateInstance(toastLiveExample);
        toastBootstrap.show();
        btnElm.click();
    }
}

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
    const btnElm = document.getElementById('close-edit-modal');

    if (toastLiveExample && toastBody) {
        toastBody.innerText = "🗑️ Delete successful!";
        const toastBootstrap = bootstrap.Toast.getOrCreateInstance(toastLiveExample);
        toastBootstrap.show();
        if (btnElm) {
            btnElm.click();
        }
    }
};

window.showErrorToast = () => {
    const toastLiveExample = document.getElementById('liveToast');
    const toastBody = document.getElementById('toast-body');
    let btnElm = document.getElementById('close-add-modal');
    if (!btnElm) {
        btnElm = document.getElementById('close-edit-modal');
    }
    if (toastLiveExample && toastBody) {
        toastBody.innerText = "❌ Something went wrong!";
        const toastBootstrap = bootstrap.Toast.getOrCreateInstance(toastLiveExample);
        toastBootstrap.show();
        btnElm.click();
    }
}

window.toggleSidebar = (isCollapsed) => {
    const mainContent = document.querySelector(".main-content");
    if (!mainContent) return;

    if (isCollapsed) {
        mainContent.classList.add("collapsed");
        localStorage.setItem("mainCollapsed", "true");
    } else {
        mainContent.classList.remove("collapsed");
        localStorage.setItem("mainCollapsed", "false");
    }
};

window.loadSidebarState = () => {
    const collapsed = localStorage.getItem("mainCollapsed") === "true";
    const mainContent = document.querySelector(".main-content");
  
    if (mainContent.classList.contains("collapsed") == false && collapsed == true) {
        mainContent.classList.add("collapsed");
    } else if (mainContent.classList.contains("collapsed") == true && collapsed == false) {
        mainContent.classList.remove("collapsed");
    } 

    return collapsed;
};

window.getDimensions = () => {
    return {
        width: window.innerWidth,
        height : window.innerHeight
    }
}

// --- Resize handler registration for Blazor components ---
// Accepts a DotNetObjectReference and calls its OnBrowserResize method
window.registerResizeHandler = (dotNetRef) => {
    try {
        if (!dotNetRef) return;

        const handler = () => {
            // call C# method with width and height
            dotNetRef.invokeMethodAsync('OnBrowserResize', window.innerWidth, window.innerHeight)
                .catch(err => console.warn('resize invoke failed', err));
        };

        // Store handler so it can be removed later
        window.__blazorResizeHandler = handler;
        window.addEventListener('resize', handler);

        // invoke once immediately so component can initialize based on current size
        handler();
    } catch (e) {
        console.error('registerResizeHandler error', e);
    }
};

window.unregisterResizeHandler = () => {
    if (window.__blazorResizeHandler) {
        window.removeEventListener('resize', window.__blazorResizeHandler);
        delete window.__blazorResizeHandler;
    }
};