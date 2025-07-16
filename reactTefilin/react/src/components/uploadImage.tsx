import { useState } from 'react';
import axios from 'axios';

const UploadImage = () => {
  const [file, setFile] = useState<File | null>(null);

  const handleFileChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    if (e.target.files && e.target.files.length > 0) {
      setFile(e.target.files[0]);
    }
  };

  const handleUpload = async () => {
    if (!file) return;

    const formData = new FormData();
    formData.append("image", file);

    try {
      const response = await axios.post("https://localhost:7179/api/Image", formData, {
        headers: {
          'Content-Type': 'multipart/form-data'
        }
      });
      console.log("Upload success", response.data);
    } catch (err) {
      console.error("Upload error", err);
    }
  };

  return (
    <div>
      <input type="file" accept="image/*" onChange={handleFileChange} />
      <button onClick={handleUpload}>העלה תמונה</button>
    </div>
  );
};

export default UploadImage;
