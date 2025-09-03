---
mode: 'agent'
description: 'Generate a landing page'
---
 
Based on the PRD below, let's generate a landing page for the application. With the following in mind:

- Let's use a modern style with gradient colors that are in black and yellow hues, nice fonts, and plenty of emoji, and have nice hover effects throughout brining it to live. Match the style of https://www.teamrockstars.nl/
- Make sure we have nice headers for navigation and a footer as well with standard links and copyright information. 
- The landing page should be responsive and look good on both desktop and mobile devices and work in light and dark modes with a toggle take some time reflect on the design and make it look good. make sure all of the key features are highlighted. 
- I have some Team Rockstars employee pictures in the wwwroot/images/employees that we could use. Update the existing Home.razor file.

# FutureYou - Self-Improvement Goal Tracking App

## Overview
Transform the existing Blazor WebAssembly app into a personal goal tracking platform for self-improvement.

## Core Features

### 📋 Goal Management
- Create and categorize goals (Health, Career, Learning, etc.)
- Set target dates and milestones
- SMART goal framework support

### 📊 Progress Tracking
- Daily check-ins and habit tracking
- Streak counters and consistency metrics
- Simple progress logging (yes/no, scale, metrics)

### 📈 Visualization
- Progress charts and dashboards
- Calendar heat maps for streaks
- Weekly/monthly progress reports

### 🎯 Motivation
- Achievement badges and celebrations
- Progress reminders
- Visual milestone recognition

## App Structure

### Pages to Build
- **Dashboard** - Goal overview and recent activity
- **Goals** - Create and manage goals
- **Track** - Daily progress entry
- **Analytics** - Charts and insights
- **Settings** - Preferences and data management

### Data Storage
- Browser localStorage for offline use
- JSON export/import for backups
- No backend required

## Success Goals
- Simple, fast daily tracking (< 30 seconds)
- Visual progress motivation
- Habit formation support
- Mobile-friendly responsive design

## Implementation
**Phase 1:** Basic goal creation and daily tracking  
**Phase 2:** Analytics and visualization  
**Phase 3:** Polish and advanced features