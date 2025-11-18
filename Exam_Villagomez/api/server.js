const { MongoClient } = require("mongodb");

const uri = "mongodb+srv://domenica:domenica@cluster0.wgtado9.mongodb.net/?appName=Cluster0";
const client = new MongoClient(uri);
const dbName = "smartWatches";

let isConnected = false;

module.exports = async (req, res) => {
  try {
    if (!isConnected) {
      await client.connect();
      isConnected = true;
      console.log("MongoDB conectado 🎉");
    }

    const db = client.db(dbName);
    const collection = db.collection("smartWatches");

    const data = await collection.find().toArray();

    res.status(200).json(data);

  } catch (error) {
    console.error("Error en API:", error);
    res.status(500).json({ error: "No se pudo obtener los datos." });
  }
};
