// ================
// Smooth scroll from hero button to planner
// ================

const startPlannerBtn = document.getElementById("startPlannerBtn");
const plannerSection = document.getElementById("planner");

if (startPlannerBtn && plannerSection) {
  startPlannerBtn.addEventListener("click", () => {
    plannerSection.scrollIntoView({ behavior: "smooth" });
  });
}

// ================
// DOM References
// ================

const sessionForm = document.getElementById("sessionForm");
const subjectInput = document.getElementById("subjectInput");
const durationInput = document.getElementById("durationInput");
const prioritySelect = document.getElementById("prioritySelect");
const timeSlotInput = document.getElementById("timeSlotInput");

const sessionList = document.getElementById("sessionList");
const totalMinutesEl = document.getElementById("totalMinutes");
const pomodoroCountEl = document.getElementById("pomodoroCount");
const loadLabelEl = document.getElementById("loadLabel");
const loadBarFill = document.getElementById("loadBarFill");
const hintText = document.getElementById("hintText");

const lightPresetBtn = document.getElementById("lightPresetBtn");
const balancedPresetBtn = document.getElementById("balancedPresetBtn");
const deepPresetBtn = document.getElementById("deepPresetBtn");

// ================
// State
// ================

let blocks = []; // {id, subject, duration, priority, timeSlot}
const STORAGE_KEY = "study-session-planner-data";

// ================
// Helpers
// ================

function renderList() {
  sessionList.innerHTML = "";

  if (blocks.length === 0) {
    const li = document.createElement("li");
    li.className = "session-item";
    li.style.justifyContent = "center";
    li.textContent = "No blocks yet. Add your first study block.";
    sessionList.appendChild(li);
    return;
  }

  blocks.forEach((block) => {
    const li = document.createElement("li");
    li.className = "session-item";
    li.dataset.id = block.id;

    const subjectSpan = document.createElement("span");
    subjectSpan.textContent = block.subject;

    const durationSpan = document.createElement("span");
    durationSpan.textContent = block.duration + " min";

    const prioritySpan = document.createElement("span");
    prioritySpan.classList.add("priority-pill");
    if (block.priority === "High") {
      prioritySpan.classList.add("priority-high");
    } else if (block.priority === "Medium") {
      prioritySpan.classList.add("priority-medium");
    } else {
      prioritySpan.classList.add("priority-low");
    }
    prioritySpan.textContent = block.priority;

    const timeSlotSpan = document.createElement("span");
    timeSlotSpan.className = "time-slot";
    timeSlotSpan.textContent = block.timeSlot || "—";

    const removeBtn = document.createElement("button");
    removeBtn.className = "remove-btn";
    removeBtn.type = "button";
    removeBtn.textContent = "Remove";

    removeBtn.addEventListener("click", () => {
      const id = li.dataset.id;
      blocks = blocks.filter((b) => String(b.id) !== String(id));
      updateAll();
      saveData();
    });

    li.appendChild(subjectSpan);
    li.appendChild(durationSpan);
    li.appendChild(prioritySpan);
    li.appendChild(timeSlotSpan);
    li.appendChild(removeBtn);

    sessionList.appendChild(li);
  });
}

function computeTotals() {
  let totalMinutes = 0;
  blocks.forEach((b) => {
    totalMinutes += b.duration;
  });

  totalMinutesEl.textContent = totalMinutes;

  const pomodoros = Math.round(totalMinutes / 25);
  pomodoroCountEl.textContent = pomodoros;

  // Load rating logic
  let label = "None";
  let className = "";
  let percent = 0;

  if (totalMinutes === 0) {
    label = "None";
    percent = 0;
    hintText.textContent = "Add your first block to see your session load.";
  } else if (totalMinutes <= 60) {
    label = "Light";
    className = "load-light";
    percent = (totalMinutes / 60) * 40; // up to 40%
    hintText.textContent = "Nice and light. You can add more if you feel okay.";
  } else if (totalMinutes <= 150) {
    label = "Balanced";
    className = "load-balanced";
    percent = 40 + ((totalMinutes - 60) / 90) * 40; // 40–80%
    hintText.textContent = "Solid, balanced load. Remember to add breaks.";
  } else {
    label = "Heavy";
    className = "load-heavy";
    percent = 80 + Math.min((totalMinutes - 150) / 90, 1) * 20; // 80–100%
    hintText.textContent = "This is a heavy session. Make sure you sleep & rest properly.";
  }

  loadLabelEl.textContent = label;
  loadLabelEl.classList.remove("load-light", "load-balanced", "load-heavy");
  if (className) {
    loadLabelEl.classList.add(className);
  }

  loadBarFill.style.width = percent + "%";
}

function updateAll() {
  renderList();
  computeTotals();
}

function saveData() {
  try {
    localStorage.setItem(STORAGE_KEY, JSON.stringify(blocks));
  } catch (e) {
    // ignore
  }
}

function loadData() {
  try {
    const raw = localStorage.getItem(STORAGE_KEY);
    if (!raw) {
      updateAll();
      return;
    }
    const parsed = JSON.parse(raw);
    if (Array.isArray(parsed)) {
      blocks = parsed;
    }
    updateAll();
  } catch (e) {
    blocks = [];
    updateAll();
  }
}

// ================
// Form Handling
// ================

if (sessionForm) {
  sessionForm.addEventListener("submit", (event) => {
    event.preventDefault();

    const subject = subjectInput.value.trim();
    const durationVal = durationInput.value.trim();
    const priority = prioritySelect.value;
    const timeSlot = timeSlotInput.value.trim();

    const duration = Number(durationVal);

    if (!subject || isNaN(duration) || duration <= 0) {
      alert("Please enter a valid subject and duration.");
      return;
    }

    const newBlock = {
      id: Date.now() + Math.random(),
      subject,
      duration,
      priority,
      timeSlot,
    };

    blocks.push(newBlock);
    updateAll();
    saveData();

    subjectInput.value = "";
    durationInput.value = "";
    timeSlotInput.value = "";
    prioritySelect.value = "Medium";
    subjectInput.focus();
  });
}

// ================
// Preset buttons
// ================

function applyPreset(type) {
  if (!confirm("This will replace your current blocks with a preset. Continue?")) {
    return;
  }

  if (type === "light") {
    blocks = [
      { id: Date.now() + 1, subject: "Review lecture notes", duration: 25, priority: "Medium", timeSlot: "7:00–7:25 PM" },
      { id: Date.now() + 2, subject: "Light reading / summary", duration: 35, priority: "Low", timeSlot: "7:30–8:05 PM" },
    ];
  } else if (type === "balanced") {
    blocks = [
      { id: Date.now() + 3, subject: "Main subject deep work", duration: 50, priority: "High", timeSlot: "2:00–2:50 PM" },
      { id: Date.now() + 4, subject: "Practice questions", duration: 40, priority: "High", timeSlot: "3:00–3:40 PM" },
      { id: Date.now() + 5, subject: "Admin / planning", duration: 30, priority: "Low", timeSlot: "3:50–4:20 PM" },
    ];
  } else if (type === "deep") {
    blocks = [
      { id: Date.now() + 6, subject: "Deep focus block 1", duration: 60, priority: "High", timeSlot: "9:00–10:00 AM" },
      { id: Date.now() + 7, subject: "Deep focus block 2", duration: 60, priority: "High", timeSlot: "10:15–11:15 AM" },
      { id: Date.now() + 8, subject: "Consolidation / notes", duration: 60, priority: "Medium", timeSlot: "11:30–12:30 PM" },
    ];
  }

  updateAll();
  saveData();
}

if (lightPresetBtn) {
  lightPresetBtn.addEventListener("click", () => applyPreset("light"));
}
if (balancedPresetBtn) {
  balancedPresetBtn.addEventListener("click", () => applyPreset("balanced"));
}
if (deepPresetBtn) {
  deepPresetBtn.addEventListener("click", () => applyPreset("deep"));
}

// ================
// Init
// ================

loadData();
