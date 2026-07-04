# Backend Management Website

## Overview

A Blazor WebAssembly management portal for lodge operators, national park authorities, game reserve managers, tour operators, and conservation agencies. This is a **frontend-only** application - all business logic, data persistence, accounting entries, and cross-cutting features are handled by the **shared AccountingWebApp API Gateway** (the same backend used by the accounting system and customer website).

**Core principle:** This website focuses ONLY on tourism/hospitality/conservation operations that are NOT already in the AccountingWebApp. It does NOT rebuild CRM, Invoicing, Inventory, Tax, HR, Projects, Banking, Reports, User Management, or any other feature already present in the AccountingWebApp.

---

## Architecture

All three applications (Accounting WebApp, Customer Website, Management Website) share the same backend API Gateway. The AccountingWebApp already provides services for:

- Auth / IAM
- CRM (Contacts, Accounts, Leads, Opportunities, Campaigns, Cases, Segmentation)
- Invoicing / Accounts Receivable / Accounts Payable
- Payments
- Inventory Management
- Tax & Compliance
- HR / Payroll
- Projects
- Banking / Treasury
- Fixed Assets
- Reports / Analytics
- AI Assistant
- Governance & Controls
- User / Role / Tenant Management

The Management Website adds tourism-specific API endpoints to the same gateway:

- /api/bookings/*
- /api/accommodation/*
- /api/activities/*
- /api/park-entry/*
- /api/packages/*
- /api/conservation/*
- /api/rangers/*
- /api/transport/*
- /api/events/*
- /api/pos/*
- /api/revenue-management/*
- /api/tour-operators/*
- /api/government-intelligence/*

---

## Features NOT Rebuilt (Already in AccountingWebApp)

| Existing Feature | How Management Site Uses It |
|---|---|
| CRM (Accounts, Contacts, Leads, Opportunities, Campaigns, Cases, Segmentation) | Links to /crm/contacts/{id} for guest profiles. Master contact record stays in CRM. |
| Invoicing / AR | Booking creates invoices via POST /api/ar/invoices. All invoice management done in AccountingWebApp. |
| Payments / Receipts | Payments recorded via POST /api/ar/receipts. Reconciliation in AccountingWebApp. |
| Inventory Management | All stock tracking, POs, supplier management in AccountingWebApp. Site views stock alerts via API. |
| Tax / VAT | Tax rates and VAT returns in AccountingWebApp Tax module. Tax-inclusive pricing via API. |
| HR / Payroll | Employee records, payroll, leave in AccountingWebApp. Site references employee IDs for shift assignments. |
| Projects | Conservation projects use AccountingWebApp Project Management for budget tracking. |
| Banking / Treasury | Bank reconciliation, transfers in AccountingWebApp. |
| Fixed Assets | Vehicles, equipment tracked in AccountingWebApp Fixed Assets. Depreciation handled there. |
| Reports / Analytics | Financial reports in AccountingWebApp. Site has tourism-specific dashboards only. |
| AI Assistant | AccountingWebApp AI handles finance queries. Site has separate tourism AI agent for operations data. |
| Governance & Controls | Approval limits, SOD, audit trails in AccountingWebApp. Site inherits these. |
| User / Role Management | Managed in AccountingWebApp Settings. Site uses same JWT + permissions. |

---

## Tech Stack

| Layer | Technology |
|---|---|
| Framework | .NET 10 Blazor WebAssembly |
| UI Library | Radzen.Blazor v10+ (Material Design) |
| CSS | Bootstrap 5 + Custom admin theme |
| Icons | Material Icons |
| Auth | JWT (via AccountingWebApp IAuthenticationService) |
| Maps | Leaflet.js (wildlife tracking, park maps, ranger patrols) |
| Charts | RadzenChart |
| Backend | AccountingWebApp API Gateway (single shared backend) |

---

## Unique Tourism Features (What This Website DOES Handle)

### 1. Reservation & Booking Management
All tourism booking types: Room, Chalet, Tent, Campsite, Game Drive, Boat Cruise, Fishing/Hiking Permits, Park Entry, Photography/Film Permits, Bird Watching/Safari Packages, Group/Corporate/Government/School/NGO/Conference bookings, Travel Agent/Tour Operator bookings. Each booking lifecycle event triggers AccountingWebApp to create Journal Entries, Invoices, and AR records.

### 2. Package Management
Package builder combining accommodation, activities, meals. Pricing tiers: Bronze, Silver, Gold, Platinum. Seasonal pricing, peak multipliers, promotional pricing, discount rules.

### 3. Accommodation Management
Room inventory (Standard, Deluxe, Executive, Presidential), lodge types (Chalets, Tents, Villas, Cabins), availability calendar, occupancy management, housekeeping schedules, maintenance schedules, room status tracking.

### 4. Park Entry Management
Pricing tiers (Citizen/Resident/International), visitor categories (Adult/Child/Student/Senior), pass types (Daily/Weekly/Annual), additional fees (Vehicle/Boat/Drone/Photography/Film).

### 5. Wildlife Activity Management
Activity scheduling (Game Drives, Walking Safaris, Night Drives, Bird Watching, Canoeing, Fishing, Horse Riding, Cultural Tours, Conservation Tours), guide assignment, vehicle assignment, route planning, capacity management.

### 6. Tour Operator Portal
External operator access, commission rate configuration, commission calculation, settlement management, guest list upload.

### 7. Transportation Management
Fleet tracking (safari vehicles, boats, buses), scheduling, driver assignment, fuel tracking, maintenance schedules, transfer management.

### 8. Event & Conference Management
Venue booking, catering packages, equipment rental (projectors, screens, PA systems), meeting rooms, resource scheduling.

### 9. Restaurant & Hospitality POS
Restaurant/bar billing, gift shop/curio sales, room charge posting, receipt printing. Revenue, inventory consumption, and VAT posted to AccountingWebApp.

### 10. Conservation Management
Wildlife census, species monitoring, animal tracking (GPS map), poaching incidents, conservation projects, population dashboards.

### 11. Ranger Management
Ranger deployment, patrol scheduling, incident reporting (poaching, illegal fishing/logging, human-wildlife conflict).

### 12. Revenue Management / AI Pricing Engine
Dynamic pricing rules (occupancy, season, demand, events, weather), revenue forecasting, occupancy forecasting, visitor number forecasting.

### 13. Government & National Park Intelligence Dashboard
Visitors by country, revenue by park/activity, employment created, tax collected (from AccountingWebApp Tax API), foreign exchange earned, occupancy rates, tourism GDP contribution, business health/sustainability/financing readiness scores.

### 14. Tourism AI Agent
Operations-focused natural language queries: package revenue, visitor forecasts, occupancy analysis, tour operator value, foreign currency earnings, package profitability, game drive utilization.

---

## Menu Structure

Dashboard (Operations / Revenue / Occupancy / Conservation)

Reservations
  All Bookings | New Booking | Walk-in | Group | Cancellations

Packages
  Package List | Package Builder | Dynamic Pricing | Promotions

Accommodation
  Room Inventory | Availability Calendar | Housekeeping | Maintenance

Park Entry
  Pricing Tiers | Pass Management | Permits

Activities
  Schedule | Guide Assignment | Capacity Management

Tour Operators
  Dashboard | Commission Config | Operator Bookings

Transportation
  Fleet | Scheduling | Fuel & Maintenance

Events
  Venue Booking | Event Management | Resource Schedule

POS
  Restaurant | Bar | Gift Shop | End-of-Day Summary

Conservation
  Census | Species Monitoring | Animal Tracking | Incidents | Projects

Rangers
  Deployment | Patrol Scheduling | Incident Reporting

Revenue Management
  AI Pricing Engine | Forecasting | Rate Calendar

Government Intelligence
  National Dashboard | Economic Impact | Scorecards

AI Agent
  Tourism AI Agent

---

## Pages

### Dashboard Section
| Page | Route | Description |
|---|---|---|
| Operations Dashboard | /dashboard | KPI cards: Occupancy %, Active Bookings, Revenue MTD, Check-ins today |
| Revenue Analytics | /dashboard/revenue | Revenue by package/accommodation/activity |
| Occupancy Analytics | /dashboard/occupancy | Occupancy heatmaps, trends, forecasts |
| Conservation Dashboard | /dashboard/conservation | Population trends, recent incidents, patrol coverage |

### Reservations Section
| Page | Route | Description |
|---|---|---|
| All Bookings | /reservations | DataGrid with filters, booking lifecycle statuses |
| New Booking | /reservations/new | Unified booking form for all booking types |
| Booking Detail | /reservations/{id} | Timeline, line items, guest info, linked invoice |
| Walk-in Booking | /reservations/walk-in | Quick POS-style booking with immediate payment |
| Group Booking | /reservations/group | Group header, member roster, room allocation |
| Cancellations | /reservations/cancellations | Cancel requests, refund processing |

### Packages Section
| Page | Route | Description |
|---|---|---|
| Package List | /packages | All packages with pricing, margin indicators |
| Package Builder | /packages/builder | Component selection, cost calculation, margin analysis |
| Dynamic Pricing | /packages/pricing | Rule engine: base x season x occupancy x event |
| Promotions | /packages/promotions | Discount rules, promo codes, seasonal offers |

### Accommodation Section
| Page | Route | Description |
|---|---|---|
| Room Inventory | /accommodation | Grid of all rooms with type, status, rate |
| Availability Calendar | /accommodation/availability | Month/week/day view, color-coded statuses |
| Housekeeping | /accommodation/housekeeping | Daily task board, staff assignment, status tracking |
| Maintenance | /accommodation/maintenance | Work orders, schedule, cost tracking |

### Park Entry Section
| Page | Route | Description |
|---|---|---|
| Pricing Tiers | /park-entry/pricing | Configure citizen/resident/international rates |
| Pass Management | /park-entry/passes | Daily/weekly/annual pass sales |
| Permits | /park-entry/permits | Drone/photo/film permits, fee tracking |

### Activities Section
| Page | Route | Description |
|---|---|---|
| Activity Schedule | /activities | Calendar of all scheduled activities |
| Guide Assignment | /activities/guides | Guide roster, assignment, availability |
| Capacity Management | /activities/capacity | Per-activity capacity limits, utilization |

### Tour Operators Section
| Page | Route | Description |
|---|---|---|
| Operator Dashboard | /tour-operators | Operator-specific bookings, revenue, commissions |
| Commission Config | /tour-operators/commissions | Rate tables, settlement schedules |
| Operator Bookings | /tour-operators/bookings | Bookings made by each operator |

### Transportation Section
| Page | Route | Description |
|---|---|---|
| Fleet Overview | /transport | Vehicle grid: type, capacity, fuel, status, service due |
| Scheduling | /transport/scheduling | Calendar with vehicle + driver assignments |
| Fuel & Maintenance | /transport/maintenance | Fuel logs, maintenance records |

### Events Section
| Page | Route | Description |
|---|---|---|
| Venue Booking | /events/venues | Venue calendar, booking form |
| Event Management | /events | Full event record: catering, equipment, resources |
| Resource Schedule | /events/resources | Equipment availability |

### POS Section
| Page | Route | Description |
|---|---|---|
| Restaurant POS | /pos/restaurant | Table map, order entry, bill split, payment |
| Bar POS | /pos/bar | Quick order, tab management |
| Gift Shop POS | /pos/gift-shop | Product catalog, barcode, stock check |
| End-of-Day Summary | /pos/end-of-day | Daily sales summary, cash-up |

### Conservation Section
| Page | Route | Description |
|---|---|---|
| Wildlife Census | /conservation/census | Species counts, population trends |
| Species Monitoring | /conservation/species | Individual animal profiles, health records |
| Animal Tracking | /conservation/tracking | Live GPS map (Leaflet.js) |
| Incidents | /conservation/incidents | Poaching, illegal activity, human-wildlife conflict |
| Conservation Projects | /conservation/projects | Project tracking, linked to AccountingWebApp Projects |

### Rangers Section
| Page | Route | Description |
|---|---|---|
| Deployment | /rangers | Map view of ranger positions, patrol routes |
| Patrol Scheduling | /rangers/patrols | Shift calendar, route assignment |
| Incident Reporting | /rangers/incidents | Report form with GPS, photos, severity |

### Revenue Management Section
| Page | Route | Description |
|---|---|---|
| AI Pricing Engine | /revenue-management/pricing | Recommended rates, occupancy forecast, rules |
| Forecasting | /revenue-management/forecasting | Revenue / occupancy / visitor forecasts |
| Rate Calendar | /revenue-management/rates | Visual rate calendar with override |

### Government Intelligence Section
| Page | Route | Description |
|---|---|---|
| National Dashboard | /government-intelligence | Visitors by country, revenue by park/activity |
| Economic Impact | /government-intelligence/economic | Employment, tax, FX, GDP contribution |
| Scorecards | /government-intelligence/scorecards | Business Health, Tourism Credit, Sustainability |

### AI Agent Section
| Page | Route | Description |
|---|---|---|
| Tourism AI Agent | /ai-agent | Natural language chat over booking + conservation + revenue data |

---

## API Endpoints Consumed (All from AccountingWebApp Gateway)

### Booking-specific endpoints (NEW)
GET    /api/bookings
POST   /api/bookings
GET    /api/bookings/{id}
PUT    /api/bookings/{id}
POST   /api/bookings/{id}/cancel
POST   /api/bookings/{id}/check-in
POST   /api/bookings/{id}/check-out
GET    /api/packages
POST   /api/packages
PUT    /api/packages/{id}
GET    /api/accommodation/rooms
GET    /api/accommodation/availability
PUT    /api/accommodation/rooms/{id}/status
POST   /api/accommodation/housekeeping
POST   /api/accommodation/maintenance
GET    /api/park-entry/pricing
POST   /api/park-entry/passes
GET    /api/activities
POST   /api/activities/schedule
PUT    /api/activities/guides
GET    /api/tour-operators
POST   /api/tour-operators/commissions
POST   /api/tour-operators/settlements
GET    /api/transport/vehicles
POST   /api/transport/fuel
POST   /api/transport/maintenance
GET    /api/events/venues
POST   /api/events/bookings
POST   /api/pos/orders
POST   /api/pos/payments
GET    /api/conservation/census
POST   /api/conservation/incidents
GET    /api/conservation/tracking
GET    /api/rangers
POST   /api/rangers/patrols
POST   /api/rangers/incidents
GET    /api/revenue-management/forecast
GET    /api/revenue-management/pricing-rules
PUT    /api/revenue-management/pricing-rules
GET    /api/government-intelligence/kpis
GET    /api/government-intelligence/scorecards
POST   /api/ai-agent/query

### Existing AccountingWebApp endpoints (consumed, not rebuilt)
GET    /api/crm/contacts/{id}
GET    /api/ar/invoices/{id}
GET    /api/inventory/stock/{sku}
GET    /api/reports/financial/kpi

---

## Permissions (Booking-Specific, in addition to AccountingWebApp permissions)

| Permission | Description |
|---|---|
| Booking.Create | Create reservations |
| Booking.Edit | Modify reservations |
| Booking.Cancel | Cancel reservations |
| Booking.ViewAll | View all bookings |
| Package.Manage | Create/edit packages and pricing |
| Accommodation.Manage | Manage room inventory and status |
| Housekeeping.Manage | Manage housekeeping schedules |
| ParkEntry.Manage | Configure park entry pricing |
| Activity.Manage | Schedule activities and assign guides |
| TourOperator.Manage | Manage operator commissions |
| Transport.Manage | Manage fleet and scheduling |
| Event.Manage | Manage events and venues |
| Pos.Operate | Use POS terminals |
| Conservation.View | View conservation data |
| Conservation.Manage | Manage conservation records |
| Ranger.Manage | Manage ranger deployment |
| RevenueManagement.View | View pricing engine and forecasts |
| RevenueManagement.Manage | Configure pricing rules |
| GovernmentIntelligence.View | View government dashboards |
| AiAgent.Use | Use tourism AI agent |

---

## Sample Data Structure (Mock Mode)

wwwroot/sample-data/tourism-management/{country}/{park}/
  bookings.json, packages.json, rooms.json, pricing-rules.json, activities.json
  guides.json, park-entry-pricing.json, tour-operators.json, vehicles.json
  events.json, pos-menu.json, rangers.json, government-kpis.json
  conservation/{ census.json, incidents.json, species.json }

---

## UI / UX Notes

- Theme: Professional navy (#1B2A4A) + teal (#00897B) - distinct from AccountingWebApp branding
- Layout: Fixed sidebar + top header + content area (consistent with AccountingWebApp patterns)
- Navigation: RadzenPanelMenu with permission filtering
- Forms: RadzenTemplateForm with validation
- Tables: RadzenDataGrid with sorting, filtering, paging
- Notifications: Radzen NotificationService (toast on CRUD operations)
- Real-time: SignalR for dashboard KPI updates, booking notifications, incident alerts

---

## Deployment

- Blazor WASM hosted on same infrastructure as AccountingWebApp (shared gateway)
- Mock mode available for demos/training
- Brotli WASM compression
- Lazy-loaded modules (Conservation, Government Intelligence, POS)
- Offline-capable for ranger field deployments (PWA with IndexedDB sync)

