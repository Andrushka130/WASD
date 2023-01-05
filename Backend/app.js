const express = require("express");
const AccountController = require("./controllers/account");
const PlayerDataController = require("./controllers/playerData");
const ErrorMiddleware = require("./middleware/error.middleware");
const Log = require("./middleware/log.middleware");
const Database = require("./db/db");

const PORT = 3000;
const dbName = "playerdata";
const param = "/:playerTag";

async function run() {
  const app = express();

  try {
    await Database.connect(dbName);
  } catch (err) {
    console.error(`could not connect to database: ${err}`);
    process.exit(1);
  }

  app.use(express.urlencoded({ extended: true }));
  app.use(express.json());
  app.use(Log.logRequests);

  const accountsRouter = express.Router();
  accountsRouter.get("", AccountController.getAccounts);
  accountsRouter.post("", AccountController.createAccount);
  accountsRouter.post(param, AccountController.login);
  accountsRouter.put(param, AccountController.changeAccount);
  accountsRouter.patch(param, AccountController.changeAccount);
  accountsRouter.delete(param, AccountController.deleteAccount);

  const playerDataRouter = express.Router();
  playerDataRouter.get("", PlayerDataController.getAllPlayerData);
  playerDataRouter.get(param, PlayerDataController.getPlayerData);
  playerDataRouter.put(param, PlayerDataController.updateHighscore);
  playerDataRouter.patch(param, PlayerDataController.updateHighscore);

  app.use("/account", accountsRouter);
  app.use("/playerData", playerDataRouter);
  app.use(ErrorMiddleware.handleServerErrors);
  app.use(ErrorMiddleware.handleNotFoundErrors);
  

  app.listen(PORT, () => {
    console.log(`Server listening on port ${PORT}`);
  });
}

run();
