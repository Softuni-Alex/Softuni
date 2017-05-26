package app.controllers;

import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;

import java.io.File;

@Controller
public class FilesController {
    @RequestMapping("/files")
    public String files(@RequestParam(value = "path",defaultValue = "c:\\")String path, Model m) {
        m.addAttribute("path", path);
        File[] allFiles =
                new File(path).listFiles();
        m.addAttribute(
                "allFiles", allFiles);
        return "files";
    }

}