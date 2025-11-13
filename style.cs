/* ================ 
   Base + Reset
=================== */

*,
*::before,
*::after {
  box-sizing: border-box;
  margin: 0;
  padding: 0;
}

:root {
  --bg: #050814;
  --bg-alt: #0a1020;
  --card: #11182a;
  --accent: #4dd0e1;
  --accent-soft: rgba(77, 208, 225, 0.2);
  --text: #f5f7ff;
  --muted: #a3acc8;
  --border: #1c2438;
  --radius-lg: 18px;
  --radius-md: 10px;
  --shadow-soft: 0 18px 40px rgba(0, 0, 0, 0.55);
  --shadow-subtle: 0 10px 25px rgba(0, 0, 0, 0.35);
}

html,
body {
  height: 100%;
}

body {
  font-family: system-ui, -apple-system, BlinkMacSystemFont, "Segoe UI", sans-serif;
  background: radial-gradient(circle at top, #192644 0, #050814 55%);
  color: var(--text);
  line-height: 1.5;
}

/* ================ 
   Layout
=================== */

main {
  max-width: 1100px;
  margin: 0 auto;
  padding: 96px 20px 72px;
}

/* ================ 
   Header / Nav
=================== */

.site-header {
  position: sticky;
  top: 0;
  z-index: 20;
  display: flex;
  align-items: center;
  justify-content: space-between;
  padding: 14px 22px;
  background: linear-gradient(to bottom, rgba(5, 8, 20, 0.95), rgba(5, 8, 20, 0.6));
  backdrop-filter: blur(14px);
  border-bottom: 1px solid rgba(255, 255, 255, 0.045);
}

.logo {
  font-weight: 700;
  letter-spacing: 0.08em;
  text-transform: uppercase;
  font-size: 0.9rem;
}

.logo span {
  color: var(--accent);
}

.nav {
  display: flex;
  gap: 18px;
}

.nav a {
  font-size: 0.85rem;
  text-decoration: none;
  color: var(--muted);
  padding: 6px 10px;
  border-radius: 999px;
  transition: color 0.2s ease, background-color 0.2s ease, transform 0.15s ease;
}

.nav a:hover {
  color: var(--text);
  background: rgba(255, 255, 255, 0.06);
  transform: translateY(-1px);
}

/* ================ 
   Hero
=================== */

.hero {
  min-height: 60vh;
  display: flex;
  align-items: center;
}

.hero-content {
  max-width: 600px;
  padding: 32px 22px;
  border-radius: var(--radius-lg);
  background: radial-gradient(circle at top left, rgba(255, 255, 255, 0.06) 0, #050814 50%);
  box-shadow: var(--shadow-soft);
  border: 1px solid rgba(255, 255, 255, 0.06);
  position: relative;
  overflow: hidden;
}

.hero-content::before {
  content: "";
  position: absolute;
  inset: -40%;
  background: radial-gradient(circle at 10% 0, rgba(77, 208, 225, 0.25), transparent 55%);
  opacity: 0.85;
  pointer-events: none;
}

.hero-content h1 {
  position: relative;
  font-size: clamp(2.1rem, 4vw, 2.8rem);
  margin-bottom: 10px;
}

.hero-content p {
  position: relative;
  color: var(--muted);
  max-width: 460px;
  margin-bottom: 20px;
  font-size: 0.95rem;
}

.primary-btn,
.secondary-btn {
  position: relative;
  border-radius: 999px;
  padding: 10px 20px;
  font-size: 0.9rem;
  border: none;
  cursor: pointer;
  font-weight: 500;
  letter-spacing: 0.03em;
  text-transform: uppercase;
  transition: transform 0.14s ease, box-shadow 0.14s ease, background 0.18s ease;
}

.primary-btn {
  background: linear-gradient(135deg, var(--accent), #82f3ff);
  color: #051018;
  box-shadow: var(--shadow-subtle);
}

.primary-btn:hover {
  transform: translateY(-1px);
  box-shadow: 0 15px 35px rgba(0, 0, 0, 0.55);
}

.secondary-btn {
  background: rgba(255, 255, 255, 0.06);
  color: var(--text);
  border: 1px solid rgba(255, 255, 255, 0.07);
}

.secondary-btn:hover {
  transform: translateY(-1px);
}

/* ================ 
   Sections generic
=================== */

section {
  margin-bottom: 72px;
}

section h2 {
  font-size: 1.5rem;
  margin-bottom: 12px;
}

section p {
  color: var(--muted);
  font-size: 0.95rem;
}

/* ================ 
   Planner
=================== */

.planner {
  background: var(--bg-alt);
  border-radius: var(--radius-lg);
  padding: 22px 16px 18px;
  box-shadow: var(--shadow-soft);
  border: 1px solid rgba(255, 255, 255, 0.06);
}

.planner-intro {
  margin-bottom: 14px;
}

/* Preset panel */

.preset-panel {
  display: flex;
  flex-wrap: wrap;
  gap: 10px;
  align-items: center;
  margin-bottom: 16px;
  padding: 10px 12px;
  border-radius: var(--radius-md);
  border: 1px dashed var(--border);
  background: rgba(255, 255, 255, 0.02);
}

.preset-panel p {
  margin-right: 4px;
  font-size: 0.85rem;
  color: var(--muted);
}

/* Form */

.session-form {
  display: grid;
  grid-template-columns: repeat(4, minmax(0, 1fr));
  gap: 14px;
  margin-bottom: 20px;
}

.form-row {
  display: flex;
  flex-direction: column;
  gap: 6px;
}

.form-row label {
  font-size: 0.8rem;
  text-transform: uppercase;
  letter-spacing: 0.05em;
  color: var(--muted);
}

input[type="text"],
input[type="number"],
select {
  background: #050814;
  border-radius: 999px;
  border: 1px solid var(--border);
  padding: 8px 11px;
  color: var(--text);
  font-size: 0.9rem;
  outline: none;
  transition: border-color 0.18s ease, box-shadow 0.18s ease, background 0.18s ease;
}

input[type="text"]:focus,
input[type="number"]:focus,
select:focus {
  border-color: var(--accent);
  box-shadow: 0 0 0 1px rgba(77, 208, 225, 0.4);
  background: #070d1a;
}

.session-form .primary-btn {
  align-self: flex-end;
  width: 100%;
}

/* Output */

.planner-output {
  display: grid;
  grid-template-columns: minmax(0, 2fr) minmax(0, 1.2fr);
  gap: 18px;
}

.session-list {
  list-style: none;
  border-radius: var(--radius-md);
  border: 1px solid var(--border);
  background: #080f1f;
  max-height: 240px;
  overflow-y: auto;
}

.session-item {
  display: grid;
  grid-template-columns: 2.3fr 1fr 1.3fr auto;
  padding: 10px 12px;
  border-bottom: 1px solid rgba(255, 255, 255, 0.04);
  gap: 8px;
  font-size: 0.85rem;
  align-items: center;
}

.session-item:last-child {
  border-bottom: none;
}

.session-item span {
  white-space: nowrap;
  overflow: hidden;
  text-overflow: ellipsis;
}

.priority-pill {
  font-size: 0.75rem;
  padding: 4px 9px;
  border-radius: 999px;
  text-transform: uppercase;
  letter-spacing: 0.05em;
}

.priority-high {
  background: rgba(255, 99, 132, 0.15);
  color: #ff9aa7;
}

.priority-medium {
  background: rgba(255, 221, 87, 0.12);
  color: #ffe69b;
}

.priority-low {
  background: rgba(129, 199, 132, 0.15);
  color: #b2ffb8;
}

.time-slot {
  color: var(--muted);
  font-size: 0.8rem;
}

.remove-btn {
  background: transparent;
  border: none;
  color: var(--muted);
  cursor: pointer;
  font-size: 0.8rem;
  padding: 4px;
  border-radius: 999px;
  transition: background 0.15s ease, color 0.15s ease;
}

.remove-btn:hover {
  background: rgba(255, 255, 255, 0.07);
  color: #fff;
}

/* Summary */

.planner-summary {
  border-radius: var(--radius-md);
  border: 1px solid var(--border);
  padding: 14px 12px;
  background: radial-gradient(circle at top right, var(--accent-soft), #050814);
  display: flex;
  flex-direction: column;
  gap: 8px;
  font-size: 0.9rem;
}

.load-label span {
  font-weight: 600;
}

.load-bar {
  position: relative;
  width: 100%;
  height: 8px;
  border-radius: 999px;
  background: rgba(255, 255, 255, 0.08);
  overflow: hidden;
  margin: 4px 0 2px;
}

.load-bar-fill {
  position: absolute;
  inset: 0;
  width: 0%;
  background: linear-gradient(90deg, #4dd0e1, #82f3ff);
  transition: width 0.25s ease;
}

.load-light {
  color: #b2ffb8;
}

.load-balanced {
  color: #ffe69b;
}

.load-heavy {
  color: #ff9aa7;
}

.hint-text {
  font-size: 0.8rem;
  color: var(--muted);
}

/* Tips section */

.tips {
  padding: 10px 4px 0;
}

.tips-list {
  margin-top: 10px;
  padding-left: 18px;
  color: var(--muted);
  font-size: 0.9rem;
}

.tips-list li {
  margin-bottom: 4px;
}

/* Footer */

.site-footer {
  border-top: 1px solid rgba(255, 255, 255, 0.04);
  padding: 16px 22px 22px;
  text-align: center;
  font-size: 0.8rem;
  color: var(--muted);
}

/* Responsive */

@media (max-width: 768px) {
  main {
    padding-top: 80px;
  }

  .site-header {
    padding-inline: 16px;
  }

  .nav {
    gap: 10px;
  }

  .nav a {
    font-size: 0.75rem;
    padding-inline: 8px;
  }

  .hero-content {
    padding: 22px 18px;
  }

  .session-form {
    grid-template-columns: 1fr 1fr;
  }

  .session-form .primary-btn {
    grid-column: 1 / -1;
  }

  .planner-output {
    grid-template-columns: 1fr;
  }

  .session-item {
    grid-template-columns: 2fr 1fr;
    grid-template-rows: auto auto;
  }
}
