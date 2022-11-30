const db = require("../db/index");

const dbName = "playerdata";


async function getAllPlayerData(req, res, next) {
    const connection = db.getConnection();

    try {
        const data = await connection.collection(dbName).find().toArray();
        if (!data) {
          res.status(400).send("PlayerData not found");
          return;
        }
        const filter = data.map((o) => ({
          playerTag: o.playerTag,
          highscore: o.highscore,
        }));
        const item = { Items: filter }; //Format benötigt für Unity
        res.status(200).send(item);
      } catch (err) {
        next(err);
      }
}


async function getPlayerData(req, res, next) {
    const connection = db.getConnection();

    try {
        const { playerTag } = req.params;
        const data = await connection.collection(dbName).findOne({ playerTag });
        if (!data) {
          res.status(400).send("PlayerData not found");
          return;
        }
        res
          .status(200)
          .send({ playerTag: data.playerTag, highscore: data.highscore });
      } catch (err) {
        next(err);
      }
}

async function changePlayerData(req, res, next) {
    const connection = db.getConnection();

    try {
        const { playerTag } = req.params;
        const highscore = parseInt(req.body.highscore);
        await connection
          .collection(dbName)
          .findOneAndUpdate(
            { playerTag: `${playerTag}` },
            { $set: { highscore } }
          );
        res.status(200).send(`PlayerData of ${playerTag} updated`);
      } catch (err) {
        next(err);
      }
}

module.exports = {
    getAllPlayerData,
    getPlayerData,
    changePlayerData
}