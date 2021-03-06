import React from "react";
import { MuiThemeProvider } from "@material-ui/core";
import themeMui from "../../themes/theme-mui";
import Dashboard from "../../components/dashboard/dashboard";
import { BrowserRouter as Router, Switch } from "react-router-dom";
import CustomersRouter from "./router/customers-router";
import DashboardRouter from "./router/dashboard-router";
import UsersRouter from "./router/users-router";
import GroupsRouter from "./router/groups-router";
import ActivitiesRouter from "./router/activities-router";
import GamesRouter from "./router/games-router";
import UserGroupsRouter from "./router/userGroups-router";
import DateFnsUtils from '@date-io/date-fns';
import { MuiPickersUtilsProvider } from "@material-ui/pickers";
//import moment from 'moment-timezone'
import RewardRouter from "./router/rewards-router";
import AuthRouter from "./router/auth-router";
//let launchMoment = require('moment')
//require('moment-timezone')
//moment.tz('America/New_York')
function App() {
  return (
    <Router>
    <MuiPickersUtilsProvider utils={DateFnsUtils}>

      <MuiThemeProvider theme={themeMui}>
        
        <Switch>
          <Dashboard>
            <AuthRouter />

            <UsersRouter />
            <GroupsRouter/>
            <CustomersRouter />
            <ActivitiesRouter />
            <UserGroupsRouter />
            <RewardRouter/>
            <GamesRouter />
            <DashboardRouter />
          </Dashboard>
        </Switch>
      </MuiThemeProvider>

    </MuiPickersUtilsProvider>
    </Router>
  );
}

export default App;
