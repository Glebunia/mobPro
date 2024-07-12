import React, { useEffect, useState } from "react";
import {
  ActivityIndicator,
  TextInput,
  FlatList,
  Text,
  View,
  Button,
} from "react-native";

import { Image } from 'react-native';
const logoImage = require('./assets/ggg.png');

const App = () => {
  const [isLoading, setLoading] = useState(true);
  const [data, setData] = useState([]);
  const [isAdded, setAdded] = useState(false);
  const [isRemoved, setRemoved] = useState(false);
  const [isUpdated, setUpdated] = useState(false);
  const [empId, setEmpId] = useState("");
  const [emp, setEmp] = useState({
    name: "",
    department: "",
    phone: "",
    street: "",
    city: "",
    state: "",
    zip: "",
    country: "",
  });

  const onChangeName = (value) => {
    setEmp({ ...emp, name: value });
  };

  const onChangeDepartment = (value) => {
    setEmp({ ...emp, department: value });
  };

  const onChangePhone = (value) => {
    setEmp({ ...emp, phone: value });
  };

  const onChangeStreet = (value) => {
    setEmp({ ...emp, street: value });
  };

  const onChangeCity = (value) => {
    setEmp({ ...emp, city: value });
  };

  const onChangeState = (value) => {
    setEmp({ ...emp, state: value });
  };

  const onChangeZip = (value) => {
    setEmp({ ...emp, zip: value });
  };

  const onChangeCountry = (value) => {
    setEmp({ ...emp, country: value });
  };

  const addEmp = () => {
    let d = `name=${emp.name}&department=${emp.department}&phone=${emp.phone}&street=${emp.street}&city=${emp.city}&state=${emp.state}&zip=${emp.zip}&country=${emp.country}`;
    fetch("http://localhost:44350/helloworldWebService1.asmx/AddEmp", {
      method: "POST",
      headers: {
        "Content-Type": "application/x-www-form-urlencoded",
      },
      body: d,
    })
      .then((response) => response.text())
      .then((responseData) => {
        setAdded(true);
        getEmp();
        clearFormEmpFields();
        console.log("Employee added successfully");
      })
      .catch((err) => {
        console.log(err);
      });
  };

  const clearFormEmpFields = () => {
    setEmp({
      name: "",
      department: "",
      phone: "",
      street: "",
      city: "",
      state: "",
      zip: "",
      country: "",
    });
  };

  const getEmp = () => {
    fetch("http://localhost:44350/helloworldWebService1.asmx/GetEmp")
      .then((response) => response.json())
      .then((json) => {
        setData(json);
      })
      .catch((error) => {
        console.error(error);
      })
      .finally(() => {
        setLoading(false);
      });
  };

  const deleteEmp = () => {
    let d = `id=${empId}`;
    fetch("http://localhost:44350/helloworldWebService1.asmx/DeleteEmp", {
      method: "POST",
      headers: {
        "Content-Type": "application/x-www-form-urlencoded",
      },
      body: d,
    })
      .then((response) => response.text())
      .then((responseData) => {
        setRemoved(true);
        getEmp();
        console.log("Employee deleted successfully");
      })
      .catch((err) => {
        console.log(err);
      });
  };

  const updateEmp = () => {
    let d = `id=${empId}&name=${emp.name}&department=${emp.department}&phone=${emp.phone}&street=${emp.street}&city=${emp.city}&state=${emp.state}&zip=${emp.zip}&country=${emp.country}`;
    fetch("http://localhost:44350/helloworldWebService1.asmx/UpdateEmp", {
      method: "POST",
      headers: {
        "Content-Type": "application/x-www-form-urlencoded",
      },
      body: d,
    })
      .then((response) => response.text())
      .then((responseData) => {
        setUpdated(true);
        getEmp();
        console.log("Employee updated successfully");
      })
      .catch((err) => {
        console.log(err);
      });
  };

  useEffect(() => {
    getEmp();
  }, []);

  return (
    <View style={{ flex: 1, padding: 24 }}>
       {/* Logo */}
       <View style={styles.logoContainer}>
        <Image
          source={logoImage}
          style={styles.logo}
          resizeMode="contain"
        />
      </View>

      {isLoading ? (
        <ActivityIndicator />
      ) : (
        <View>
          {/* Employee Input Fields */}
          <TextInput
            placeholder={"Employee name"}
            onChangeText={(value) => onChangeName(value)}
            value={emp.name}
            style={styles.input}
          />
          <TextInput
            placeholder={"Department"}
            onChangeText={(value) => onChangeDepartment(value)}
            value={emp.department}
            style={styles.input}
          />
          <TextInput
            placeholder={"Phone"}
            onChangeText={(value) => onChangePhone(value)}
            value={emp.phone}
            style={styles.input}
          />
          <TextInput
            placeholder={"Street"}
            onChangeText={(value) => onChangeStreet(value)}
            value={emp.street}
            style={styles.input}
          />
          <TextInput
            placeholder={"City"}
            onChangeText={(value) => onChangeCity(value)}
            value={emp.city}
            style={styles.input}
          />
          <TextInput
            placeholder={"State"}
            onChangeText={(value) => onChangeState(value)}
            value={emp.state}
            style={styles.input}
          />
          <TextInput
            placeholder={"Zip"}
            onChangeText={(value) => onChangeZip(value)}
            value={emp.zip}
            style={styles.input}
          />
          <TextInput
            placeholder={"Country"}
            onChangeText={(value) => onChangeCountry(value)}
            value={emp.country}
            style={styles.input}
          />

          {/* Add Employee Button */}
          <Button title="Add Employee" onPress={addEmp} />

          {/* Id Input Field for Update/Delete */}
          <TextInput
            placeholder={"Id to be updated or removed"}
            onChangeText={(value) => setEmpId(value)}
            value={empId}
            style={styles.input}
          />

          {/* Delete Employee Button */}
          <Button title="Delete Employee" onPress={deleteEmp} />

          {/* Update Employee Button */}
          <Button title="Update Employee" onPress={updateEmp} />

          {/* FlatList to Display Employees */}
          <FlatList
            data={data}
            keyExtractor={(item) => item.Id.toString()}
            renderItem={({ item }) => (
              <Text style={styles.listItem}>
                {item.Id}. {item.Name} - {item.Department} - {item.Phone} - {item.Street} - {item.City} - {item.State} - {item.Zip} - {item.Country}
              </Text>
            )}
          />
        </View>
      )}
    </View>
  );
};

const styles = {
  logoContainer: {
    alignItems: "center",
    marginBottom: 20,
  },
  logo: {
    width: 200, // Adjust width according to the logo size
    height: 80, // Adjust height according to the logo size
    resizeMode: "contain",
  },
  input: {
    height: 40,
    borderColor: "#ccc",
    borderWidth: 1,
    marginBottom: 10,
    paddingHorizontal: 10,
  },
  buttonText: {
    color: "#fff", // White text color
    fontSize: 18,
  },
  listItem: {
    marginBottom: 10,
  },
};

export default App;
