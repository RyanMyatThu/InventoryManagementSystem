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

window.printSection = (id) => {
    const el = document.getElementById(id);
    if (!el) return;

    const win = window.open('', '_blank');

    win.document.write(`
        <html>
        <head>
            <title>Print</title>
        <style>
        .print-only {
        display: block !important;
    }

    #print-voucher-template, #print-voucher-template * {
        visibility: visible !important;
    }

    #print-voucher-template {
        display: block !important;
        position: absolute;
        left: 0;
        top: 0;
        width: 100%;
        background: white;
        font-family: 'Segoe UI', 'Pyidaungsu', 'Myanmar Text', sans-serif;
        -webkit-print-color-adjust: exact; /* Crucial for printing gradients/colors */
        print-color-adjust: exact;
    }

    /* Yellow Header Section with Gradient */
    .voucher-header {
        background: linear-gradient(to bottom, #FFD700 0%, #FFD700 80%, #ffffff 100%);
        padding: 20px 10px 30px 10px;
        text-align: center;
        border-bottom: 2px solid #D32F2F;
    }

    .title-container {
        display: flex;
        justify-content: space-between;
        align-items: center;
        max-width: 90%;
        margin: 0 auto;
    }

    .header-logo {
        height: 70px;
        width: auto;
        mix-blend-mode: multiply;
    }

    /* Text Groups */
    .voucher-title-mm {
        color: #D32F2F;
        font-size: 34px;
        font-weight: bold;
        margin-bottom: 2px;
    }

    .burmese-green-text {
        color: #1B5E20;
        font-size: 20px;
        font-weight: bold;
        line-height: 1.2;
    }

    .burmese-green-subtext, .phone-numbers {
        color: #1B5E20;
        font-size: 15px;
        font-weight: bold;
        margin-top: 4px;
    }

    .phone-icon {
        background-color: #1B5E20;
        color: white;
        padding: 0px 5px;
        border-radius: 3px;
        font-size: 12px;
    }

    /* Customer Info & Red Dotted Lines */
    .customer-info-section {
        padding: 20px 15px;
    }

    .info-row {
        display: flex;
        align-items: flex-end;
        margin-bottom: 12px;
        gap: 10px;
    }

    .label-red {
        color: #D32F2F;
        font-weight: bold;
        font-size: 15px;
        white-space: nowrap;
    }

    .dotted-line {
        flex-grow: 1;
        border-bottom: 1.5px dotted #D32F2F;
        min-height: 1.2em;
        padding-left: 8px;
        color: #333;
    }

    /* Table Styling: Rounded Boxes */
    .voucher-table {
        width: 100%;
        border-collapse: separate;
        border-spacing: 6px;
        margin-top: 5px;
    }

        .voucher-table th {
            background: linear-gradient(to bottom, #FFD700, #FBC02D);
            color: #D32F2F;
            padding: 10px;
            border-radius: 8px 8px 0 0;
            border: 1px solid #aaa;
            font-weight: bold;
        }

        .voucher-table td {
            border: 1.5px solid #aaa;
            border-radius: 12px;
            padding: 12px;
            height: 400px; /* Vertical box look */
            vertical-align: top;
            background: white;
        }

    /* Totals Summary */
    .voucher-summary-container {
        display: flex;
        justify-content: flex-end;
        padding: 20px;
    }

    .summary-box {
        width: 280px;
    }

    .summary-line {
        display: flex;
        justify-content: space-between;
        border: 1.5px solid #aaa;
        border-radius: 20px;
        padding: 6px 18px;
        margin-bottom: 6px;
        color: #D32F2F;
        font-weight: bold;
    }

    /* Footer & Signature */
    .voucher-footer {
        text-align: center;
        color: #D32F2F;
        font-family: 'Brush Script MT', cursive;
        font-size: 28px;
        margin-top: 10px;
    }

    .signature-line {
        margin-top: 30px;
        color: #D32F2F;
        font-style: italic;
        padding-left: 20px;
    }
        </style>
            </head>

        <body>
            ${el.outerHTML}
        </body>
        </html>
    `);

    win.document.close();

    win.onload = () => {
        win.print();
        win.close();
    };
};