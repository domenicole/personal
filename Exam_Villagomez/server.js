const express = require("express");
const cors = require("cors");
const { MongoClient } = require("mongodb");

const app = express();
app.use(cors());
app.use(express.json());

const uri = "mongodb+srv://domenica:domenica@cluster0.wgtado9.mongodb.net/?appName=Cluster0";

const client = new MongoClient(uri);
const dbName = "smartWatches";

app.get("/smartwatches", async (req, res) => {
    try {
        await client.connect();
        const db = client.db(dbName);
        const collection = db.collection("smartWatches");

        const data = await collection.find().toArray();
        res.json(data);

    } catch (error) {
        console.error("Error:", error);
        res.status(500).json({ error: "Error retrieving data." });
    }
});

app.listen(3000, () => {
    console.log("Server running on http://localhost:3000");
});
