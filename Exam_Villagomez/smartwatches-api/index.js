const { MongoClient } = require("mongodb");

const uri = "mongodb+srv://domenica:domenica@cluster0.wgtado9.mongodb.net/?appName=Cluster0";
const client = new MongoClient(uri);
const dbName = "smartWatches";

module.exports = async (req, res) => {
    try {
        await client.connect();
        const db = client.db(dbName);
        const collection = db.collection("smartWatches");

        const data = await collection.find().toArray();
        res.status(200).json(data);

    } catch (error) {
        console.error("Error:", error);
        res.status(500).json({ error: "Error retrieving data." });
    }
};