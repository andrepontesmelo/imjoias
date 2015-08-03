/**
 * $Id: ServletTest.java,v 1.1.1.1 2004/01/15 15:56:04 dwalters Exp $
 */

package bardemo;

import javax.servlet.*;
import javax.servlet.http.*;
import java.io.*;
import jbarcodebean.*;

/**
 * Servlet example code.
 *
 * @version 1.0.2
 */
public class ServletTest extends HttpServlet {

  JBarcodeBean bb;

  public void init(ServletConfig conf) throws ServletException {
    super.init(conf);
    bb = new JBarcodeBean();
    bb.setCodeType(new ExtendedCode39());
    bb.setShowText(true);
  }

  public void doGet(HttpServletRequest req, HttpServletResponse resp)
    throws ServletException, IOException {

    resp.setContentType("image/gif");
    OutputStream out = resp.getOutputStream();

    bb.setCode(req.getParameter("code"));
    bb.gifEncode(out);
  }

}
